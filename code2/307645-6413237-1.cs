    public class TestObj
    {
        public int MyProperty { get; set; }
        public override bool Equals(object obj)
        {
            return (base.Equals(obj) || (obj is TestObj  && 
                ((TestObj)obj).MyProperty == MyProperty));
        }
    }
