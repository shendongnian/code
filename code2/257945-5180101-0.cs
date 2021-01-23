    TimeSpan output = new TimeSpan(0,0,0);
    using (var enumerator = input.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
          var begin = enumerator.Current.ClockInOutTime;
          if(!enumerator.MoveNext())
            break;
          var end = enumerator.Current.ClockInOutTime;
          output += (end - begin);
        }
    }
