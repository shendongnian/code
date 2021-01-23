    private void subscribeAll()
    {
      SomeClass.MotionCompleted += new EventHandler(HandlerMethod);
      // other subscription
    }
    private void unSubscribeAll()
    {
      SomeClass.MotionCompleted -= new EventHandler(HandlerMethod);
      // other subscription
    }
