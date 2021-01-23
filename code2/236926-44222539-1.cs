    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
    namespace Service
    {
      class Server
      {
        public static void Main (string[] args)
        {
            HttpServer Service = new QuizzServer (8);
            Service.Start (80);
            for (bool coninute = true; coninute ;)
            {
                string input = Console.ReadLine ().ToLower();
                switch (input)
                {
                    case "stop":
                        Console.WriteLine ("Stop command accepted.");
                        Service.Stop ();
                        coninute = false;
                        break;
                    default:
                        Console.WriteLine ("Unknown Command: '{0}'.",input);
                        break;
                }
            }
        }
      }
    }
