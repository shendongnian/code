    namespace Test
    {
      using System;
      using System.Xml.Linq;
    
      public interface IAction
      {
        DisplayMessageDelegate DisplayMessage { get; set; };
        void Execute();
        XElement Serialize(XName elementName);
      }
    
      public delegate void DisplayMessageDelegate(string message);
    }
