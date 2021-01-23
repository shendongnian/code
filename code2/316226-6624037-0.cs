      public CardInformationAvailable OnDataRecieve 
      {
        set
        {
             
             if(value == null)
               _cardReaderBase.OnDataReady -= value;
             else
               _cardReaderBase.OnDataReady += value; 
                                                  
         }
      }
