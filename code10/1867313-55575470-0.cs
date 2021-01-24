        public static void DoIt()
        {
            TrackRecordVM record = new TrackRecordVM();
            string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
            foreach (decimal? value in record.GetType().GetRuntimeProperties()
                .Where(p => months.Contains(p.Name))
                .Select(pi => pi.GetValue(record, null)))
            {
                //do stuff
            }
        }
