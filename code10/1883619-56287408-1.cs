    using Microsoft.Lync.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    
    namespace UserStatus
    {
        public class DoThis
        {
    
            private readonly Timer _timer;
            public DoThis()
            {
                _timer = new Timer(1000 * 2) { AutoReset = true };
                _timer.Elapsed += TimerElapsed;
            }
            private void TimerElapsed(object sender, ElapsedEventArgs e)
            {
                DoThis2();
            }
            public void Start()
            {
                _timer.Start();
            }
            public void Stop()
            {
                _timer.Stop();
            }
    
            void DoThis2()
            {
    
                Stop();
    
                var theClient = LyncClient.GetClient();
                Contact self = theClient.Self.Contact;
                
    
                if ((self.GetContactInformation(ContactInformationType.Availability)).ToString() == "6500")
                {
                    Console.WriteLine("busy");
                }
                if ((self.GetContactInformation(ContactInformationType.Availability)).ToString() == "3500")
                {
                    Console.WriteLine("available");
                }
                if ((self.GetContactInformation(ContactInformationType.Availability)).ToString() == "15500")
                {
                    Console.WriteLine("away");
                }
                Start();
            }
        }
    }
