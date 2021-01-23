    class foo {
       bool isAssigned;
       void someMethod()
       {
          if (!isAssigned)
          {
            lock (this)
            {
                if (!isAssigned) proxy.SomeEvent += ...;
                isAssigned = true;
            }
          }
       }
