    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.NetworkInformation;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static CountdownEvent countdown;
            static void Main(string[] args)
            {
                countdown = new CountdownEvent(1);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string ipBase = "10.10.5.";
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
                Console.WriteLine("Took {0} milliseconds", sw.ElapsedMilliseconds);
                Console.ReadLine();
            }
            static void p_PingCompleted(object sender, PingCompletedEventArgs e)
            {
                string ip = (string)e.UserState;
                //Console.WriteLine("{0}:\t{1} ({2})", ip, e.Reply.Status, e.Reply.RoundtripTime);
                if (e.Reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
                }
                countdown.Signal();
            }
        }
    }
