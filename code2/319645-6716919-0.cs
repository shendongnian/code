    public interface IFirst
    {
        int asd { get; set; }
    }
    public interface ISecond
    {
        int zxc { get; set; }
    }
    public abstract class MyAbstractClass<T> where T : class
    {
        public abstract T Properties {get; set;}
    }
    public class MyClass : MyAbstractClass<MyClass.PropertyClass>
    {
        public class PropertyClass : IFirst
        {
            public int asd
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
    
        public override MyClass.PropertyClass Properties
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
    public class MyNextClass : MyAbstractClass<MyNextClass.PropertyClass>
    {
        public class PropertyClass : MyClass.PropertyClass, ISecond
        {
            public int zxc
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
        public void test()
        {
            Properties.zxc = 5;
        }
    }
