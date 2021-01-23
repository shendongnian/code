    private void StartKeyboardListener()
    {
        var thread = new Thread(() => {
                                          while (!this.stopping)
                                          {
                                              ConsoleKeyInfo key = System.Console.ReadKey(true);
                                              this.messageQueue.Enqueue(new KeyboardMessage(key));
                                          }
                                      });
        thread.IsBackground = true;
        thread.Start();
    }
