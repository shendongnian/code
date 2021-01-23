    public interface IThing<T>
    {
        T MyEnum { get; set; }
        string doAction(T enumOptionChosen, string valueToPassIn);
    }
    public class Something : IThing<Something.SpecialEnum>
    {
        public enum SpecialEnum
        {
            Item1,
            Item2,
            Item3
        }
        public SpecialEnum MyEnum { get; set; }
        public string doAction(SpecialEnum enumOptionChosen, string valueToPassIn)
        {
            return "something";
        }
    }
