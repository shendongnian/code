    public interface IDoSomething
    {
        string DoIt();
    }
    public class ClassOne : TextBox, IDoSomething
    {
        public string DoIt()
        {
            return "OK from a textbox";
        }
    }
    public class ClassTwo : Panel, IDoSomething
    {
        public string DoIt()
        {
            return "OK from a panel";
        }
    }
