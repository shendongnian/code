      float best = 0f;
      for (int i = 2147483000; ; ++i)
      {
        float f = (float)i;
        try
        {
          checked
          {
            int v = (int)f;
          }
          best = f;
        }
        catch (OverflowException)
        {
          string report = string.Join(Environment.NewLine, 
            $"   max float = {best:g10}",
            $"min overflow = {f:g10}",
            $"     max int = {i - 1}");
          Console.Write(report);
          break;
        }
      }
