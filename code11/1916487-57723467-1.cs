    var lmaxEnumerator = lmaxTicks.GetEnumerator();
    LmaxTick lmaxPrev = null;
    
    while (lmaxEnumerator.MoveNext())
    {
        if (DateTimeOffset.FromUnixTimeMilliseconds((long)lmaxEnumerator.Current.TimestampMsec) >= date.Date + time.TimeOfDay)
        {
            break;
        }
        lmaxPrev = lmaxEnumerator.Current;
    }
