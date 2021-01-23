    CallResult TryDo(Func<Object[], OutType> action, params Object[] args) {
      try {
        return new CallResult(action(args));
      }
      catch (Exception ex) {
        return new CallResult(ex);
      }
    }
