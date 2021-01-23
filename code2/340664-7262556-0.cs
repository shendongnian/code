        public int totalCount = default(int);
        protected void Test_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                int count = default(int);
                string text = e.Row.Cells[0].Text;
                int.TryParse(text, out count);
                totalCount = totalCount + count;
            }
        }
