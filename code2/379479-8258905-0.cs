              private delegate void InvokeDelegate();
              
              public void DoSomething()
              {
                   if (InvokeRequired)
                   {
                        Invoke(new InvokeDelegate(DoSomething));
                        return;
                   }
                   // dosomething
              }
