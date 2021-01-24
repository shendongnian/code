    public abstract class BaseClass
    {
        public bool IsTrue { get; protected set; }
    }
    public abstract class DerivedClass
    {
         var dictionary = new Dictionary<string, object>();
         dictionary.Add("IsTrue", IsTrue => base.IsTrue = IsTrue); // error will come here
    }
