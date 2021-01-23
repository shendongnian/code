using System;
using System.Net;
using System.Threading;
using System.Net.Http;
bool check() //Checking for Internet Connection 
            {
                while (true)
                {
                    try
                    { var i = new Ping().Send("www.google.com").Status;
                        if (i == IPStatus.Success)
                        { Console.WriteLine("connected");
                            return true;
                        }
                        else { return false; }
                        }
                       
                    catch (Exception)
                    {
                        Console.WriteLine("Not Connected");
                        Thread.Sleep(2000);
                        continue;
                    }
                }
                
            };
            check();
