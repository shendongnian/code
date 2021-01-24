    [TestCaseSource(typeof(MyTestData), nameof(GetDataString))]
    public void TestMethod2(List<Config> configs)
    {
       ...
    }
    public class MyTestData
    {
        public static IEnumerable GetDataString()
        {
            var datas = new List<Config>();             
            datas.Add(new Config("Nick", "Coldson"));
                
            return new TestCaseData(datas);
        }
    }  
