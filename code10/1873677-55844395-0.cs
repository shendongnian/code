    class MessageOrigin {
     private Printer _parentPrinter;
     MessageOrigin(Printer parentPrinter) 
     {
       _parentPrinter = parentPrinter;
     } 
     public void SendMessageToPrintClass(string message) 
        {
           // obviously you need to create the method/property in the Printer class.
           _parentPrinter.Message = message;
        }
    }
