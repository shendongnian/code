        [Flags]
        enum DaysBitMask { Sun = 1, Mon = 2, Tues = 4, Wed = 8, Thu = 16, Fri = 32, Sat = 64 }
        static DayOfWeek FindNextDay(DaysBitMask mask, DayOfWeek currentDay)
        {
            DayOfWeek dayCursor = currentDay;
            int counter = 0;
            do
            {
                int cursorMask = 0x01 << (int)dayCursor;
                int operationResult = (cursorMask & (int)mask);
                if (operationResult > 0)
                    return dayCursor;
                dayCursor = (DayOfWeek)(((int)dayCursor + 1) % 7); // moving to the next day
                counter++;
            }
            while (counter < 7);
            throw new InvalidOperationException("Wrong flow. We shouldn't be here");
        }
