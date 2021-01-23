        public DateTime? TestDt; 
        public Parse(DataRow row)
        {
            if (!row.IsNull("TEST_DT"))
                TestDt = Convert.ToDateTime(row["TEST_DT"]);
        }
