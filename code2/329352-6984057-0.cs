    bool isWrong = false;
    bool isLarge = false;
    if (!Int32.TryParse(rawValue, out int32Holder))
    {
          if (!Int64.TryParse(rawValue, out int64Holder))
          {
               isWrong = true;
          }
          else
          {
               isLarge = true;
          }
    }
