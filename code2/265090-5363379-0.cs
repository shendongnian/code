    public double getdata(int x) //this method gets the data and stores it in the class data members
    {
      callid = ++x ;
      Console.WriteLine("Enter the number minutes: ");
      minutes = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Enter the price per minute: ");
      costpermin = Convert.ToDouble(Console.ReadLine());
      pricepercall = minutes * costpermin;
      return pricePercall; 
    }
