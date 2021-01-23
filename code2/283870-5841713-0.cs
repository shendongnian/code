    static void Main(string[] args)
            {
    
                Console.WriteLine("Give me an integer between 1 and 12, and I will give you the month");
    
                int monthInteger = int.Parse(Console.ReadLine());
    
                DateTime newDate = new DateTime(DateTime.Now.Year, monthInteger, 1);
    
                Console.WriteLine("The month is: " + newDate.ToString("MMMM"));
                Console.WriteLine();
    
                Console.WriteLine("Give me a month name (ex: January), and I will give you the month integer");
    
                string monthName = Console.ReadLine();
    
                monthInteger = DateTime.ParseExact(monthName + " 1, " + DateTime.Now.Year, "MMMM d, yyyy", System.Globalization.CultureInfo.InvariantCulture).Month;
    
                Console.WriteLine("The month integer is " + monthInteger);
                Console.ReadLine();
    
            }
