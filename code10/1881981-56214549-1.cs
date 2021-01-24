        public DateTime RoundTime(DateTime input)
        {
            DateTime output = new DateTime(input.Year, input.Month, input.Day, input.Hour, 0, 0);
            if(input.Minute % 3 == 1)
            {
                output.AddMinutes(input.Minute - 1);
            }
            else if (input.Minute % 3 == 2)
            {
                output.AddMinutes(input.Minute + 1);
            }
            else
            {
                output.AddMinutes(input.Minute);
            }
            return output;
        }
