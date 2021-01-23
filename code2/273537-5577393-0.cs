    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management;
    using System.Threading;
    using System.Diagnostics;
    
    namespace CPULoad
    {
        class Program
        {
            static int TargetCpuUtilization = 50;
            static int AverageWindow = 10;
            // A somewhat large number gets better results here.
            static int ThreadsPerCore = 8;
            // WMI is *very slow* here - behavior not very good.
            // A PerformanceCounter will be used if not using WMI.
            static bool UseWMI = false;
    
            static int CoreCount () {
                ManagementObject mo = new ManagementObject("Win32_ComputerSystem.Name=\"" + Environment.MachineName + "\"");
                return int.Parse("" + mo["NumberOfLogicalProcessors"]);
            }
    
            static void Main (string[] args) {
                var threadCount = CoreCount() * ThreadsPerCore;
                var threads = new List<Thread>();
                for (var i = 0; i < threadCount; i++) {
                    Console.WriteLine("Starting thread #" + i);
    
                    Func<int> sampler = null;
                    if (UseWMI) {
                        var searcher = new ManagementObjectSearcher(
                            @"root\CIMV2",
                            "SELECT PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor");
                        sampler = () => {
                            var allCores = searcher.Get().OfType<ManagementObject>().First();
                            return int.Parse("" + allCores["PercentProcessorTime"]);
                        };
                    } else {
                        var cpuCounter = new PerformanceCounter {
                            CategoryName = "Processor",
                            CounterName = "% Processor Time",
                            InstanceName = "_Total",
                        };
                        sampler = () => {
                            return (int)cpuCounter.NextValue();
                        };
                    }
                    
                    var thread = new Thread(() => {
                        Loader(sampler);
                    });
                    thread.IsBackground = true;
                    thread.Priority = ThreadPriority.Highest;
                    thread.Start();
                    threads.Add(thread);
                }
                Console.ReadKey();
                Console.WriteLine("Fin!");
            }
    
            static void Loader (Func<int> nextSample) {
                int cycleLength = 100000;
                int sleepDuration = 1;
                Random r = new Random();
                
                int temp = DateTime.Now.Millisecond;
                var polls = new LinkedList<int>();
    
                while (true) {
                    for (int i = 0; i < cycleLength; i++) {
                        // do some work
                        temp = (int)(temp * Math.PI);
                    }
                    Thread.Sleep(sleepDuration);
    
                    {
                        // add new sample
                        var sample = nextSample();
                        if (polls.Count >= AverageWindow) {
                            polls.RemoveFirst();
                        }
                        polls.AddLast(sample);
                    }
                    var avg = (int)polls.Average();
    
                    Console.WriteLine("avg:" + avg + " sleep: " + sleepDuration + " cyclelength: " + cycleLength);
                    // Manipulating both the sleep duration and work duration seems
                    // to have the best effect. We don't change both at the same
                    // time as that skews one with the other.
                    if (r.NextDouble() < 0.5) {
                        sleepDuration += (avg < TargetCpuUtilization) ? -1 : 1;
                        sleepDuration = (int)Math.Max(0, sleepDuration);
                    } else {
                        cycleLength += (avg < TargetCpuUtilization) ? 1000 : -1000;
                        cycleLength = (int)Math.Max(5000, cycleLength);
                    }
                }
            }
        }
    }
