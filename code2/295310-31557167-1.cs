    static void Main(string[] args)
        {
            string dateStrings =  "2014-09-01T03:00:00+00:00" ;
           
                DateTime convertedDate = DateTime.Parse(dateStrings);
                Console.WriteLine("  {0} ----------------- {1}",
                              
                                  convertedDate,DateTime.Parse(convertedDate.ToString()).ToString("dd/MM/yyyy"));
             
            Console.Read();
        }
