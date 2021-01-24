    public void main()
    {
       TestClass1.Object1 = TestClass;
       
       Class1 temp =  TestClass1.Object1 as Class1;
       // safe guard in case cast fails 
       if(temp !=null)
       {
          //Now you can do what you wanted
          Console.WriteLine(temp.Value1);
       }
    }
