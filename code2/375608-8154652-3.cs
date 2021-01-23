        public DataTable GetInfo()
        {
            string Query = "select location from zone";
            DataSet Set = GetInformation(Query);
            return Set.Tables[0];
        }
