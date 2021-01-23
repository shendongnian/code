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
            // What to try to get :-)
            static int TargetCpuUtilization = 50;
            // An average window too large results in bad harmonics.
            static int AverageWindow = 7;
            // A somewhat large number gets better results here.
            static int ThreadsPerCore = 8;
            // WMI is *very slow* here - behavior not very good.
            // A PerformanceCounter will be used if not using WMI.
            static bool UseWMI = false;
    
            static int CoreCount () {
                var sys = new ManagementObject("Win32_ComputerSystem.Name=\"" + Environment.MachineName + "\"");
                return int.Parse("" + sys["NumberOfLogicalProcessors"]);
            }
    
            static Func<int> GetWmiSampler () {
                var searcher = new ManagementObjectSearcher(
                    @"root\CIMV2",
                    "SELECT PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor");
                return () => {
                    var allCores = searcher.Get().OfType<ManagementObject>().First();
                    return int.Parse("" + allCores["PercentProcessorTime"]);
                };
            }
    
            static Func<int> GetCounterSampler () {
                var cpuCounter = new PerformanceCounter {
                    CategoryName = "Processor",
                    CounterName = "% Processor Time",
                    InstanceName = "_Total",
                };
                return () => {
                    return (int)cpuCounter.NextValue();
                };
            }
    
            static void Main (string[] args) {
                var threadCount = CoreCount() * ThreadsPerCore;
                var threads = new List<Thread>();
                for (var i = 0; i < threadCount; i++) {
                    Console.WriteLine("Starting thread #" + i);                
                    var thread = new Thread(() => {
                        Loader(UseWMI ? GetWmiSampler() : GetCounterSampler());
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
                Random r = new Random();
                int cycleCount = 0;
                int cycleLength = 10;
                int sleepDuration = 15;
                int temp = 0;
                var samples = new LinkedList<int>(new[] { 50 });
    
                while (true) {
                    cycleCount++;
                    var busyLoops = cycleLength * 1000;
                    for (int i = 0; i < busyLoops; i++) {
                        // Do some work
                        temp = (int)(temp * Math.PI);
                    }
                    // Take a break
                    Thread.Sleep(sleepDuration);
                    
                    {
                        // Add new sample
                        // This seems to work best when *after* the sleep/yield
                        var sample = nextSample();
                        if (samples.Count >= AverageWindow) {
                            samples.RemoveFirst();
                        }
                        samples.AddLast(sample);
                    }
                    var avg = (int)samples.Average();
    
                    Console.WriteLine(string.Format("avg:{0:d2} sleep:{1:d2} cycle-length:{2}",
                        avg, sleepDuration, cycleLength));
                    // Manipulating both the sleep duration and work duration seems
                    // to have the best effect. We don't change both at the same
                    // time as that skews one with the other.
                    // Favor the cycle-length adjustment.
                    if (r.NextDouble() < 0.05) {
                        sleepDuration += (avg < TargetCpuUtilization) ? -1 : 1;
                        // Don't let sleep duration get unbounded upwards or it
                        // can cause badly-oscillating behavior.
                        sleepDuration = (int)Math.Min(24, Math.Max(0, sleepDuration));
                    } else {
                        cycleLength += (avg < TargetCpuUtilization) ? 1 : -1;
                        cycleLength = (int)Math.Max(5, cycleLength);
                    }
                }
            }
        }
    }
