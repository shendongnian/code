                IICalendar iCal = new iCalendar();
            iCal.AddChild(timeZones.GetTimeZone("America/New_York"));
            iCal.AddChild(timeZones.GetTimeZone("America/Denver"));            
            // Set the event to start at 11:00 A.M. New York time on January 2, 2007.
            evt.Start = new iCalDateTime(2007, 1, 2, 11, 0, 0, "America/New_York", iCal);
