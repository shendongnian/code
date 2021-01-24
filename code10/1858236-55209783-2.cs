        public DateTime RoundDateTimeMinutes(DateTime date)
        {
            var minutesDiff = date.Minute % 10;
            return date.AddMinutes(-minutesDiff);            
        }
