        private string FormatHours(string value)
        {
            var timeValues = Regex.Split(value, @"[\shm]", RegexOptions.IgnoreCase).Where(s => !string.IsNullOrEmpty(s));
            if (timeValues == null || timeValues.Count() != 2)
                return null;
            
            string[] arr = timeValues.ToArray();
            return string.Format(@"{0:hh}.{1:mm}", arr[0], arr[1]);
        }
