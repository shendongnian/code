        bool IsValidDateTime(int year, int month, int day, out DateTime result)
        {
            try
            {
                result = new DateTime(year, month, day);
                return true;
            }
            catch (System.Exception ex)
            {
                result = DateTime.Now; // assign a value
                return false;
            }
        }
