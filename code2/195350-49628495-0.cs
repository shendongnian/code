    public interface IStruct
    {
        int Age { get; set; }
    }
    
    public struct Struct : IStruct
    {
        public int Age { get; set; }
    }
    
    public class Test
    {
        IStruct strInterface { get; set; }
        Struct strExplicitly;
    
        public Test()
        {
            strInterface = new Struct();
            strExplicitly = new Struct();
        }
    
        public void ChangeAge()
        {
            strInterface.Age = 2;
            strExplicitly.Age = 2;
        }
    }
