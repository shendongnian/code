    private void save(object sender, EventArgs e)
    {
       if (sender is ClassOne)
       {
           ((ClassOne)sender).SaveObject();
       }
       else if (sender is ClassTwo)
       {
           ((ClassTwo)sender).SaveObject();
       }
       else if (sender is ClassThree)
       {
           ((ClassThree)sender).SaveObject();
       }
       else
       {
           throw new Exception("Unknown type");
       }
    }
