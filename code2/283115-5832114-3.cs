    public class BaseClass
    {
        public virtual int Id { get; set; }   
    }
    
    public class TestClassOne : BaseClass
    {
        public virtual string Name { get; set; }
    }
    
    public class TestClassTwo : BaseClass
    {
        public virtual string Value { get; set; }
        public virtual string Hobby { get; set; }
    }
    
    public class TestClassThree : BaseClass
    {
        public virtual string Month { get; set; }
        public virtual int Day { get; set; }
    }
    
    public class TestClassFour : BaseClass
    {
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
    }
