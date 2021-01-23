    class tts {
      Process process1;
      public void speak() { .... }
      public void stopspeak() {
        if (process1 != null)
          process1.Kill();
        process1 = null;
      }
    }
