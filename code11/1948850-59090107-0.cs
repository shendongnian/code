    class Program
    {
        [Serializable]
        public class Test
        { 
            [JsonIgnore]
            public Action<string> AFunc { get; set; }
            public string[] AFuncIdentifier { get; set; }
        }
        public static class Methods
        {
            public static void Log(string additional)
            {
                Console.WriteLine(additional);
            }
        }
        static void Main(string[] args)
        {
            var myTest = new Test();
            myTest.AFunc = Methods.Log;
            myTest.AFuncIdentifier = new string[] { myTest.AFunc.Method.DeclaringType.FullName,
                myTest.AFunc.Method.Name };
            var raw = JsonConvert.SerializeObject(myTest);
            var test = JsonConvert.DeserializeObject<Test>(raw);
            RestoreFunc(test);
            test.AFunc("a");
        }
        private static void RestoreFunc(Test test)
        {
            var fIdentifier = test.AFuncIdentifier;
            var t = Assembly.GetExecutingAssembly().GetType(fIdentifier[0]);
            var m = t.GetMethod(fIdentifier[1]);
            test.AFunc = (Action<string>)m.CreateDelegate(typeof(Action<string>));
        }
    }
