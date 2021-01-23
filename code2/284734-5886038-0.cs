    void DataReader_Runner(object state)
    {
      Stream strm = (Stream)state;
      while (true) {
        int bi = strm.ReadByte(); // This blocks waiting for data...
        if (bi == -1)
          break;
        byte b = (byte)bi; // Now we know that it is not the special -1 int value
        ... use the new byte ...
      }
    }
