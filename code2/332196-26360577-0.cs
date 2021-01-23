        private bool IsValidSqlDateTime(DateTime? dateTime)
        {
            if (dateTime == null) return true;
            
            DateTime minValue = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());
            DateTime maxValue = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString());
            if (minValue > dateTime.Value || maxValue < dateTime.Value)
                return false;
            return true;
        }
