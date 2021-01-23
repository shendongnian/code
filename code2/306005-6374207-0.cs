    public int getPinCount(int terminalId, ref int pinnumber)
    {
         using (var dbEntities = new DatabaseAccess.Schema.BMIEntityModel())
         {
              DateTime dateNow = DateTime.Now;
              return (from pin in dbEntities.PinIds
                      where pin.TerminalID == terminalId
                      && pin.PinExpireDateTime < dateNow
                      select pin).Count();
         }
         return 0;
    }
