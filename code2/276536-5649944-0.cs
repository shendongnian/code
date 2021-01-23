    using System;
    
    class Program
    {
        static void Main()
        {
    	// Taken from MySQL: SELECT CURTIME()
    	//                   SELECT TIME(...)
    	string mySqlTime = "23:50:26";
    	DateTime time = DateTime.Parse(mySqlTime);
    
    	// Taken from MySQL: SELECT TIMESTAMP(...)
    	string mySqlTimestamp = "2003-12-31 00:00:00";
    	time = DateTime.Parse(mySqlTimestamp);
    	Console.WriteLine(time);
    
    	// Taken from MySQL: SELECT CURDATE()
    	//                   SELECT DATE(...)
    	string mySqlDate = "2008-06-13";
    	time = DateTime.Parse(mySqlDate);
    	Console.WriteLine(time);
        }
    }
