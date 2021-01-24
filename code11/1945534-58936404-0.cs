        void Start()
        {
            //New object month of type Month (class Month)
            Maanden maand;
            maand = new Maanden();
            //Calling the methods
            PrintMaanden();
            VraagMaand("Typ het nummer van de maand: ");
            Console.ReadKey();
        }
        void PrintMaand(Maanden maand)
        {
            Console.WriteLine(maand);
        }
        void PrintMaanden()
        {
            int teller = 0;
            for (Maanden i = Maanden.Januari; i <= Maanden.December; i++)
            {
                teller = teller + 1;
                Console.WriteLine(string.Format("{0,2}. {1}", teller, i));
            }
        }
        Maanden VraagMaand(string question)
        {
            //Read number of the month
            Console.Write(question);
            string month = Console.ReadLine();
            Maanden monthNumber = (Maanden)int.Parse(month);
            Console.Write("{0} => ", month);
            PrintMaand(monthNumber);
            return monthNumber;
        }
    }
