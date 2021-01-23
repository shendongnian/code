    public interface IAction
    {
        Action<string> DisplayMessage { get; set; }
        void Execute();
        XElement Serialize(XName elementName);
    }
