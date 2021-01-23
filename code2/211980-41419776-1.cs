    interface Iphone{
      
       void Money();
    
    }
    
    interface Ipen{
    
       void Price();
    }
    
    
    class Demo : Iphone, Ipen{
    
      void Iphone.Money(){    //it is private you can't give public               
    
          Console.WriteLine("You have no money");
      }
    
      void Ipen.Price(){    //it is private you can't give public
    
          Console.WriteLine("You have to paid 3$");
      }
    
    }
    
    
    // So you have to cast to call the method
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Demo d = new Demo();
    
                Iphone i1 = (Iphone)d;
    
                i1.Money();
    
                ((Ipen)i1).Price();
    
                Console.ReadKey();
            }
        }
    
      // You can't call methods by direct class object
