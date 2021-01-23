            String currentDateTime = DateTime.Now.ToString("G");
            Console.WriteLine(currentDateTime);
            System.DateTime dateTime = System.DateTime.Parse(currentDateTime);
            
            Console.WriteLine(dateTime.ToString("hh.mm.ss.ffffff"));
