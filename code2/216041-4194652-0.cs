    while (true)
    {
      try
      {
         // call webservice
         // handle results
         break;
      }
      catch (TemporaryException e)
      {
        // do any logging you wish
        continue;
      }
      catch (FatalException e)
      {
        // do any logging you wish
        break;
      }
    }
