    public interface IMyOtherString : IMyString
    {
        int LOL { get; set; }
    }
    public class AnotherString : MyString, IMyOtherString
    {
        public int LOL { get; set; }
    }
