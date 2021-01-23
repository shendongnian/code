    int test;
    if(int.TryParse(textbox1.Text, test))
    {
      // parse succeeded can check if natural
      if(test > 0)
      {
        // do something
      }
    }
