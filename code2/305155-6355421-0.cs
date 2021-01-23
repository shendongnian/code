      public static void DoEverySecond(int seconds, Func<bool> action)
        {
            for (var i = 0; i < seconds; i++)
            {
                if(!action.Invoke())
                {
                    return;
                }
                Thread.Sleep(1000);
            }
        }
