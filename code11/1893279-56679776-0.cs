    private bool _enterLong;
    private bool _enterShort;
    
    private void SetEntrySignal()
    {
    
       if (Slope(EMA(20), 5, 0) > -0.01 && Slope(EMA(20), 5, 0) < 0.01)
       {
          _enterLong = Close[0] > Open[0];
          _enterLong &= Open[0] > High[1];
       }
       else
       {
          _enterShort = Close[0] < Open[0];
          _enterShort &= Open[0] < Low[1];
        }
    }
