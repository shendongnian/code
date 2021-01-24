    static void Main(string[] args)  
        {  
            // Get current DateTime. It can be any DateTime object in your code.  
            DateTime aDate = DateTime.Now;  
  
            // Format Datetime in different formats and display them  
            Console.WriteLine(aDate.ToString("MM/dd/yyyy"));  
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));  
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));  
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));  
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));  
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy"));  
            Console.WriteLine(aDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"));  
            Console.WriteLine(aDate.ToString("MM/dd/yyyy HH:mm"));  
            Console.WriteLine(aDate.ToString("MM/dd/yyyy hh:mm tt"));  
            Console.WriteLine(aDate.ToString("MM/dd/yyyy H:mm"));  
            Console.WriteLine(aDate.ToString("MM/dd/yyyy h:mm tt"));  
            Console.WriteLine(aDate.ToString("MM/dd/yyyy HH:mm:ss"));  
            Console.WriteLine(aDate.ToString("MMMM dd"));  
            Console.WriteLine(aDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));  
            Console.WriteLine(aDate.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’"));  
            Console.WriteLine(aDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss"));  
            Console.WriteLine(aDate.ToString("HH:mm"));  
            Console.WriteLine(aDate.ToString("hh:mm tt"));  
            Console.WriteLine(aDate.ToString("H:mm"));  
            Console.WriteLine(aDate.ToString("h:mm tt"));  
            Console.WriteLine(aDate.ToString("HH:mm:ss"));  
            Console.WriteLine(aDate.ToString("yyyy MMMM"));  
  
            Console.ReadKey();  
        }  
