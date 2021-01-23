    class State {
      readonly Object locker = new Object();
      public void ModifyState() {
        lock (this.locker) {
          ...
        }
      }
      public String AccessState() {
        lock (this.locker) {
          ...
          return ...
        }
      }
    }
