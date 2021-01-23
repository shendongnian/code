    For example, i want to add a DateTime array of 4 elements:                     DateTime[] myarray=new DateTime [4]; //the array is created 
    int year, month, day;                //variables of date are created             
    for(int i=0; i<myarray.length;i++)
    { 
      Console.WriteLine("Day");
      day=Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Month");
      month=Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Year");
      year=Convert.ToInt32(Console.ReadLine());
    
      DateTime date =new DateTime(year,month,day); //here is created the object DateTime, that contains day, month and year of a date
    
    myarray[i]=date; //and then we set each date in each position of the array
    }
