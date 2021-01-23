    public interface ICommonControl : IXmlSerializable {
        // ...
    }
    [Serializable]
    public class MyLabel : System.Windows.Forms.Label, ICommonControl {
        // Implement your common control interface and serializable methods here
    }
