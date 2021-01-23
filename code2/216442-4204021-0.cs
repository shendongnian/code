    public class Base
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public virtual IDictionary<string, string> DictInstance
        {
            get { return this.dictionary; }
        }
    }
    public class Derived : Base
    {
        private MySpecialDictionary otherDictionary = new MySpecialDictionary();
        public override IDictionary<string, string> DictInstance
        {
            get { return this.otherDictionary; }
        }
    }
