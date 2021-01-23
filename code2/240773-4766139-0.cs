    public class PrinterState
    {
         public Boolean IsPaperTrayEmpty { get; set; }
         public Int32 CartridgeLevel { get; set; }
    }
    
    public class ColorPrintProvider
    {
         public PrinterState CurrentState { get; private set; }
    
         public void UpdateCurrentState()
         {
             // update the current state
             // based on / after some events like RequestForPrint, PrintCompleted...
         }
    }
