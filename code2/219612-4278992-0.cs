    int GetPositionAfterMatch(byte[] data, byte[]pattern)
    {
      for (int i = 0; i < data.Length; i++)
      {
        bool match = true;
        for (int k = 0; k < pattern.Length; k++)
        {
          if (data[i + k] != pattern[k])
          {
            match = false;
            break;
          }
        }
        if (match)
        {
          return i + pattern.Length;
        }
      }
    }
