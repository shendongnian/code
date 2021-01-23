    void Main()
    {
    	DateTime[] dates = new DateTime[] { new DateTime(2000, 1, 1), new DateTime (2000, 3, 25) };
    	object[] objDates = new object[2];
    	Array.Copy(dates, objDates, 2);
    	
    	foreach (object o in objDates) {
    		Console.WriteLine(o);
    	}
    }
