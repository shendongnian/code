    public class ReflectionTest
        {
            public int Method1(){return 1;}
            public int Method2() { return 2; }
            public int Method3() { return 3; }
            public int Method4() { return 4; }
            public int Method5() { return 5; }
            public int Method6() { return 6; }
        }
        [Test]
        public void TestStatic()
        {
            for (var i = 1; i <= 100000; i++)
            {
                var reflectTest = new ReflectionTest();
                reflectTest.Method1();
                reflectTest.Method2();
                reflectTest.Method3();
                reflectTest.Method4();
                reflectTest.Method5();
                reflectTest.Method6();
            }
        }
        [Test]
        public void TestReflection()
        {
            var fullName = typeof (ReflectionTest).FullName;
            for (var i = 1; i <= 100000; i++)
            {
                var type = Assembly.GetExecutingAssembly().GetType(fullName, true, true);
                var reflectTest = Activator.CreateInstance(type);
                for (var j = 1; j <= 6; j++)
                    type.GetMethod("Method" + j.ToString()).Invoke(reflectTest, null);
            }
        }
