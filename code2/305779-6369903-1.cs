    int test;
    if(int.TryParse(textbox1.Text, out test))
    {
      // parse succeeded can check if natural
      if(test > 0)
      {
        // do something
      }
    }
