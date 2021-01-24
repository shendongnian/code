    using System;
        using System.Diagnostics;
        using System.Threading;
        using System.Threading.Tasks;
        namespace LockReleaseTest
        {
            class Program
            {
                public static object locker = new object();
                public static ManualResetEvent mre = new ManualResetEvent(false);
                public static bool isWorkDone = false;
                public class StateObject
                {
                    public int ThreadNumber;
                    public string Criticla_Parameter;
                    public int ItTakes = 1000;
                }
                static void Main(string[] args)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        StateObject state = new StateObject();
                        state.ThreadNumber = i;
                        state.Criticla_Parameter = "critical " + i.ToString();
                        ThreadPool.QueueUserWorkItem(method, state);
                    }
                    Thread.Sleep(13000); // wait previous process to be done
                    Console.WriteLine("In order to test release lock after 2.5 sec press enter");
                    Console.ReadLine();
                    for (int i = 0; i < 5; i++)
                    {
                        StateObject state = new StateObject();
                        state.ThreadNumber = i;
                        state.ItTakes = (i + 1) * (1000);
                        state.Criticla_Parameter = "critical " + i.ToString();
                        ThreadPool.QueueUserWorkItem(method2, state);
                    }
                    Console.ReadLine();
                }
                public static void method(Object state)
                {
                    lock (locker)
                    {
                        // critcal section
                        string result = ((StateObject)state).Criticla_Parameter;
                        int ThreadNumber = ((StateObject)state).ThreadNumber;
                        Console.WriteLine("Thread " + ThreadNumber.ToString() + " entered");
                        // simultation of process            
                        Thread.Sleep(2000);
                        Console.WriteLine("ThreadNumber is " + ThreadNumber + " Result of proccess : " + result);
                        // critcal section
                    }
                }
                public static void method2(Object state)
                {
                    if (Monitor.TryEnter(locker, -1))
                    {
                        mre.Reset();
                        ThreadPool.QueueUserWorkItem(criticalWork, state);
                        Thread.Sleep(200);
                        ThreadPool.QueueUserWorkItem(LockReleaser, ((StateObject)state).ThreadNumber);
                        mre.WaitOne();
                        Monitor.Exit(locker);
                    }
                }
                public static void criticalWork(Object state)
                {
                    isWorkDone = false;
                    string result = ((StateObject)state).Criticla_Parameter;
                    int ThreadNumber = ((StateObject)state).ThreadNumber;
                    int HowMuchItTake = ((StateObject)state).ItTakes;
                    // critcal section
                    Console.WriteLine("Thread " + ThreadNumber.ToString() + " entered");
                    // simultation of process            
                    Thread.Sleep(HowMuchItTake);
                    Console.WriteLine("ThreadNumber " + ThreadNumber + " work done. critical parameter is : " + result);
                    isWorkDone = true;
                    mre.Set();
                    // critcal section
                }
                public static void LockReleaser(Object ThreadNumber)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Restart();
                    do
                    {
                        if (isWorkDone) return; // when work is done don't release lock // continue normal
                    } while (sw.Elapsed.Seconds <= 2.5); // timer in order to release lock
                    if (!isWorkDone) // more than 2.5 sec time took but work was not done
                    {
                        Console.WriteLine("ThreadNumber " + ThreadNumber + " work NOT done. Lock must be released ");
                        mre.Set();
                    }
                }
            }
        }
