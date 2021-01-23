        private bool ParseDateString()
        {
            var theIncomingParam = Request.Params.Get("__EVENTARGUMENT").ToString(); 
            DateTime myDate;
            if (DateTime.TryParse(theIncomingParam, CultureInfo.InvariantCulture, DateTimeStyles.None, out myDate))
            {
                int TheMonth = myDate.Month;
                int TheDay = myDate.Day;
                int TheYear = myDate.Year;
                // TODO: further processing of the values just read
                return true;
            }
            else
            {
                return false;
            }
        }
