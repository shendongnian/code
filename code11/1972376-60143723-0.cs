    public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken)
    {
      //error checking
      Task.DelayPromise delayPromise = new Task.DelayPromise(cancellationToken);
      if (cancellationToken.CanBeCanceled)
        delayPromise.Registration = cancellationToken.InternalRegisterWithoutEC((Action<object>) (state => ((Task.DelayPromise) state).Complete()), (object) delayPromise);
      if (millisecondsDelay != -1)
      {
        delayPromise.Timer = new Timer((TimerCallback) (state => ((Task.DelayPromise) state).Complete()), (object) delayPromise, millisecondsDelay, -1);
        delayPromise.Timer.KeepRootedWhileScheduled();
      }
      return (Task) delayPromise;
    }
