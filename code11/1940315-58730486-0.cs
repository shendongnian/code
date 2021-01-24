            DateTime dt = new DateTime();
            string x = "03/10/1999 22:10:10";
            dt = DateTime.Parse(x);
            Console.WriteLine(dt.ToShortDateString());
            Console.WriteLine(dt.ToShortTimeString());
            Console.ReadLine();
