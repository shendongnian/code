    public void setBaudRateForModem( int slotId, int rate ) {
      PciDevice device = getInsertedCard( slotId );
      Modem modem = device as Modem;
      if( null != modem )
      {
        modem.baudRate = rate;
      }
    }
