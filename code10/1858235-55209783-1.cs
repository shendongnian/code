        public DateTime RoundDateTimeMinutes(DateTime date, bool roundUp = true)
        {
            var minutesDiff = date.Minute % 10;
            
            if (minutesDiff == 5)
            {
                if (roundUp)
                {
                    date = date.AddMinutes(minutesDiff);
                }
                else
                {
                    date = date.AddMinutes(-minutesDiff);
                }
            }            
            else if (minutesDiff > 5)
            {
                date = date.AddMinutes(10 - minutesDiff);
            }
            else
            {
                date = date.AddMinutes(-minutesDiff);
            }
            return date;
        }
