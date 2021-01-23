    public class FactoryClass  //FactoryClass with Interface named "IINterface2"
    {
       public IInterface2 sample_display()   //sample_display() is a instance method for Interface
       {
           IInterface2 inter_object = null;   //assigning NULL for the interface object
           inter_object = new Class1();       //initialising the interface object to the class1()
           return inter_object;   //returning the interface object
       }
    }
  
