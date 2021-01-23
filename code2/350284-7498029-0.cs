    public enum Language
    {
        CS,
        Java,
        CPP
    }
        
    public class CS: BaseClass { }
    public class Java: BaseClass { }
    public class Cpp: BaseClass { }
    public class BaseClass
    {
        public abstract BaseClass ConvertTo(Language lang);
    }
