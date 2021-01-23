    public  abstract class MyBaseClass
    {
        private Dictionary<string, string> dic { get; set; }
        public MyBaseClass()
        {
        }
        protected void Add(string key, string value)
        {
            dic.Add(key, value);
        }
    }
    public class MyClass1 : MyBaseClass
    {
        public MyClass1()
            : base()
        {
        }
        public void Save(string TCKimlikNo, string AdSoyAd)
        {
            base.Add(TCKimlikNo, AdSoyAd);
        }
    }
