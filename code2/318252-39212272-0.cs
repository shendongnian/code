    public enum eTimeFragment
        {
            hours,
            minutes,
            seconds,
            milliseconds
        }
    public static long DiferenceIn(this DateTime dtOrg, DateTime Diff, eTimeFragment etf = eTimeFragment.minutes)
            {
    
                long InTicks = 1;
                switch (etf)
                {
                    case eTimeFragment.hours:
                        InTicks = DateTime.MinValue.AddHours(1).Ticks;
                        break;
                    case eTimeFragment.seconds:
                        InTicks = DateTime.MinValue.AddSeconds(1).Ticks;
                        break;
                    case eTimeFragment.milliseconds:
                        InTicks = DateTime.MinValue.AddMilliseconds(1).Ticks;
                        break;
                    case eTimeFragment.minutes:
                    default:
                        InTicks = DateTime.MinValue.AddMinutes(1).Ticks;
                        break;
                }
    
                if (dtOrg > Diff)
                    return dtOrg.AddTicks(Diff.Ticks * -1).Ticks / InTicks;
                else
                    return Diff.AddTicks(dtOrg.Ticks * -1).Ticks / InTicks;
    
            }
