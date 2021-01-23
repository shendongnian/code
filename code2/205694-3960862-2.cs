        private IList<your object> PopulateYourObjectListFromData(DataTable dt)
        {
            IList<your object> newsReachArticleList = new List<your object>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    <your object> dto = new <your object>();
                    <your object>.PropertyToFill = Convert.ToString(row["column name"]);
                }
            }
        }
