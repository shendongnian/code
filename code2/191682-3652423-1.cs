    int x = 5;
    switch(x)
    {
      case 4:
      {
        int y = 3;
        goto case 5;
      }
      case 5:
      {
        y = 4;//compiling error
        //...                      
        break;
      }
    }
