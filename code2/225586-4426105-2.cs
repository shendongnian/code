    public interface ICommonControl : System.Xml.Serialization.IXmlSerializable {
        // ...
    }
    [Serializable]
    public class MyLabel : System.Windows.Forms.Label, ICommonControl {
        // Implement your common control interface and serializable methods here
    }
