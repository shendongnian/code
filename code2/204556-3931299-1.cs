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
    private void MessageLoop()
    {
        while (!this.stopping)
        {
            Message message = this.messageQueue.Dequeue(DEQUEUE_TIMEOUT);
            if (message != null)
            {
                switch (message.MessageType)
                {
                    case MessageType.Keyboard:
                        HandleKeyboardMessage((KeyboardMessage) message);
                        break;
                    ...
                }
            }
            Thread.Yield(); // or Thread.Sleep(0)
        }
    }
