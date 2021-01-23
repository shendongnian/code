    public interface IThing
    {
        TheEnum MyEnum { get; set; }
        string DoAction(TheEnum enumOptionChosen, string valueToPassIn);
    }
    public class Thing : IThing
    {
        public TheEnum MyEnum { get; set; }
        public string DoAction(TheEnum enumOptionChosen, string valueToPassIn)
        {
            return "Something";
        }
    }
