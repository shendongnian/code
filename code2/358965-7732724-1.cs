        public static void InitAndTest()
        {
            var something = new SomeCrazyClass<int>(); //or whatever type your method returns
            var _service = new SomeService();
            something.SetExecutableMethod(() => _service.SomeMethod1("param1 placeholder", "param2 placeholder"));
            var result1 = something.ExecuteMethod(_service,new object[] {"Test1", "Test2"});
            var result2 = something.ExecuteMethod(_service, new object[] {"Test3", "Test4"});
        }
