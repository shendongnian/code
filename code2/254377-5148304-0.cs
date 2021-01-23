    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SKYPE4COMLib;
    
    namespace Example
    {
        class SkypeExample
        {
            static void Main(string[] args)
            {
                SkypeClass _skype = new SkypeClass();
                _skype.Attach(7, false);
    
                IEnumerable<SKYPE4COMLib.User> users = _skype.Friends.OfType<SKYPE4COMLib.User>();
    
                users
                    .Where(u => u.OnlineStatus == TOnlineStatus.olsOnline)
                    .OrderBy(u => u.FullName)
                    .ToList()
                    .ForEach(u => Console.WriteLine("'{0}' is an online friend.", u.FullName));
    
                Console.ReadKey();
            }
        }
    }
