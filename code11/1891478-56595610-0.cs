    bool continueLoop = true;
    while(continueLoop)
    {
       var result = GetResult(...);
       switch(result)
       {
          case MyResult.Continue:
          //do nothing
          break;
          case MyResult.Retry:
          // continue the loop
          break;
          case MyResult.Finish:
          // break the loop
          continueLoop = false;
          break;
       }
    }
