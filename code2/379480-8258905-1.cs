          private delegate void InvokeDelegate(string text);
          public void DoSomething(string text)
          {
               if (InvokeRequired)
               {
                    Invoke(new InvokeDelegate(DoSomething), text);
                    return;
               }
               // dosomething with text
          }
