        public static long convertDateTimeToSeconds(DateTime dateTimeToConvert) {
            // According to Wikipedia, there are 10,000,000 ticks in a second, and Now.Ticks is the span since 1/1/0001. 
            long NumSeconds= dateTimeToConvert.Ticks / 10000000;
            return NumSeconds;
        }
