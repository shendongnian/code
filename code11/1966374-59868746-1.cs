        public static int changeCount(List<Record> Records)
        {
            int previous = Records[0].Value;
            var result_change = 0;
            //i used sorted records by month you can do not this if order is not sensitive
            foreach (var rec in Records.OrderBy(x=>x.Month))
            {
                if (rec.Value != previous)
                {
                    result_change++;
                }
                previous = rec.Value;
            }
            return result_change;
        }
