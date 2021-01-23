        static byte[,] LookupTable = new byte[128, 7];
        static void BuildLookupTable()
        {
            for (int i = 0; i < 128; ++i)
            {
                DayMask mask = (DayMask)i;
                for (int day = 0; day < 7; ++day)
                {
                    LookupTable[i, day] = (byte)FindNextDay(mask, (DayOfWeek)day);
                }
            }
        }
