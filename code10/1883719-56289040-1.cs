        [Flags]
        enum DaysBitMask { Sun = 1, Mon = 2, Tues = 4, Wed = 8, Thu = 16, Fri = 32, Sat = 64 }
        static DayOfWeek FindNextDay(DaysBitMask mask, DayOfWeek currentDay)
        {
            DayOfWeek dayCursor = currentDay;
            for (int counter = 0; counter < 7; counter++)
            {
                int cursorMask = 0x01 << (int)dayCursor;
                int operationResult = (cursorMask & (int)mask);
                if (operationResult > 0)
                    return dayCursor;
                dayCursor = (DayOfWeek)(((int)dayCursor + 1) % 7);
            }
            throw new InvalidOperationException("We shouldn't be here");
        }
