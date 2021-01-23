    public void Write(string Message, bool AlsoWriteToFile) {
      if(AlsoWriteToFile) {
        using(StreamWriter s = new StreamWriter("filename.txt") {
          s.WriteLine(Message);
        }
      }
      Console.WriteLine(Message);
    }
