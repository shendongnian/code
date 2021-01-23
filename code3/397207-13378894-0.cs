    System.Linq.IQueryable<MyEFTable Object type> MyObject = null;
    if(city == "New York City")
    {
      MyObject = from x in MyEFTable
                 where x.CostOfLiving == "VERY HIGH"
                 select x.*;
    }
    else
    {
      MyObject = from x in MyEFTable
                 where x.CostOfLiving == "MODERATE"
                 select x.*;
    }
    foreach (var item in MyObject)
    {
      Console.WriteLine("<item's details>");
    }
