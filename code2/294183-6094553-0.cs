     class BasePDU
     {
         string Name { get; set; }
         ...
     }
     class PDUType1 : BasePDU
     {
         ...
     }
     ...
     class PDUReceiver
     {
         public event EventHandler<PDUReceivedEventArgs> PDUReceived;
 
         private void ParsePDU(byte[] data)
         {
              BasePDU pdu;
              switch (byte[0]) // PDU type selector
              {
                  ....    parse PDU based on type
              }
              OnPDUReceived(pdu);
         }
          private void OnPDUReceived(BasePDU pdu)
          {
               var handler = PDUReceived;
               if (handler != null)
               {
                    handler(this, new PDUReceivedEventArgs(pdu));
               }
          }
     }
