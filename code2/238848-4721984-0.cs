    public static bool MoveToFront<T>(this T[] mos, Predicate<T> match)
      {
        if (mos.Length == 0)
        {
          return false;
        }
        var idx = Array.FindIndex(mos, match);
        if (idx == -1)
        {
          return false;
        }
        var tmp = mos[idx];
        Array.Copy(mos, 0, mos, 1, idx);
        mos[0] = tmp;
        return true;
      }
