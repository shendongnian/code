    public CardReader
    {
       public event OnDataReady;
       private CardReaderBase _cardReaderBase;
    
       public event OnDataReady OnDataReadyEvent
       {
          add 
          {
             _cardReaderBase.OnDataReady += value;
          }
          remove
          {
             _cardReaderBase.OnDataReady -= value;
          }
       } 
    }
