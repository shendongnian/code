    public void MainLoop()
    {
      while (true)
      {
        this.Invoke(new MethodInvoker(() =>
                    {
                      foreach(GameObject ob in mygame.scenes[CurrentScene].objects)
                      {
                        //run code here
                      }
                    }
                    ));
      }
    }
