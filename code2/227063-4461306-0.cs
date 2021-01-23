    //create a global radioCheckStatus
    RadioCheckStatus radioStatus = RadioCheckStatus.none;
    
    //declare your enum
    private enum RadioCheckStatus
    {
          none = 0,
          rbFrenchImp = 1,
          rbFrenchMet = 2,
          rbEnglishImp = 3,
          rbFrenchEuro = 4
    }
    
    //On CheckedChanged event of your radioButtons set it to changed radioButtons enum
    private void rbFrenchImp_CheckedChanged(object sender, EventArgs e)
    {
          radioStatus = RadioCheckStatus.rbFrenchImp;
    }
    
    // whereever you want to check the selected value
    switch (radioStatus)
    {
          case RadioCheckStatus.rbFrenchImp:
          {
                 break;
          }
          case RadioCheckStatus.rbFrenchEuro:
          {
                 break;
          }
          case RadioCheckStatus.rbEnglishImp:
          {
                 break;
          }
          case RadioCheckStatus.rbFrenchMet:
          {
                 break;
          }
          default:
                 break;
    }
