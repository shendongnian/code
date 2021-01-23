    public class ReflectionTest
    {
        public void Method1() {Debug.WriteLine("1");}
        public void Method2() {Debug.WriteLine("2");}
        public void Method3() {Debug.WriteLine("3");}
        public void Method4() {Debug.WriteLine("4");}
        public void Method5() {Debug.WriteLine("5");}
        public void Method6() {Debug.WriteLine("6");}
    }
    
    ...
    
    public void TestStatic()
    {
       for(i=1; i<=1000;i++)
       {
           var reflectTest = new ReflectTest();
           reflectTest.Method1();
           reflectTest.Method2();
           reflectTest.Method3();
           reflectTest.Method4();
           reflectTest.Method5();
           reflectTest.Method6();
       }
    }
    
    public void TestReflection()
    {
       for(var i=1;i<=1000;i++)
       {
          var type = GetType("ReflectTest");
          var reflectTest = Activator.CreateInstance(type);
                    for(var j=1;j<=6;j++)
             type.GetMethod("Method"+j.ToString()).Invoke();
       }
    }
