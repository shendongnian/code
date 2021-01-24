     public void wristbandScan(string barcode) {
       bool result = hasScanCode(barcode); 
       ValidTicketEventArgs args = new ValidTicketEventArgs() { 
         Result = result,
         Message = result ? "WB linked" : "WB already linked",
         Barcode = barcode, 
       };  
       OnValidTicketEvent(args);       
     }
