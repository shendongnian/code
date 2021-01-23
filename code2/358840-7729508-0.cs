            DateTime Event1 = DateTime.Now;
            DateTime Event2 = DateTime.Now.AddYears(10);
            Action<DateTime> eventPointer;  // A Pointer?
            if (true)
            {
                eventPointer = x => { Event1 = x; };
            }
            else
            {
                eventPointer = x => { Event2 = x; };
            }
            eventPointer(DateTime.Now.AddYears(5));
            Console.WriteLine(Event1);
            Console.WriteLine(Event2);
