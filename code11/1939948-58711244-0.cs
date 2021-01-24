    Class1 TestClass = new Class1(15);
    Class2 TestClass1 = new Class2();
    public void main()
    {
       TestClass1.Object1 = TestClass;
       //Now you can do what you wanted
       Console.WriteLine(TestClass1.Object1.Value1);
    }
