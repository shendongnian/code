    interface iPopulate
    {
       void Populate(int id);
    }
    
    class MyBaseClass
    {
      //whatever
    }
    
    class Warehouse : MyBaseClass, iPopulate
    {
       void Populate(int id)
       {
           Console.WriteLine("Populate Warehouse");
       }
    }
    
    class Items : MyBaseClass, iPopulate
    {
       void Populate(int id)
       {
          Console.WriteLine("Populate Item");
       }
    }
