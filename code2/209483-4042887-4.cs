    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.NetworkInformation;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    using System.Net.Sockets;
    namespace ConsoleApplication1
    {
        class Program
        {
            static CountdownEvent countdown;
            static int upCount = 0;
            static object lockObj = new object();
            const bool resolveNames = true;
            static void Main(string[] args)
            {
                countdown = new CountdownEvent(1);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string ipBase = "10.22.4.";
                for (int i = 1; i < 255; i++)
                {
                    string ip = ipBase + i.ToString();
                    Ping p = new Ping();
                    p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                    countdown.AddCount();
                    p.SendAsync(ip, 100, ip);
                }
                countdown.Signal();
                countdown.Wait();
                sw.Stop();
                TimeSpan span = new TimeSpan(sw.ElapsedTicks);
                Console.WriteLine("Took {0} milliseconds. {1} hosts active.", sw.ElapsedMilliseconds, upCount);
                Console.ReadLine();
            }
            static void p_PingCompleted(object sender, PingCompletedEventArgs e)
            {
                string ip = (string)e.UserState;
                if (e.Reply != null && e.Reply.Status == IPStatus.Success)
                {
                    if (resolveNames)
                    {
                        string name;
                        try
                        {
                            IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                            name = hostEntry.HostName;
                        }
                        catch (SocketException ex)
                        {
                            name = "?";
                        }
                        Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
                    }
                    else
                    {
                        Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
                    }
                    lock(lockObj)
                    {
                        upCount++;
                    }
                }
                else if (e.Reply == null)
                {
                    Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
                }
                countdown.Signal();
            }
        }
    }
