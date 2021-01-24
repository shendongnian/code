     public DataTable DoGrid()
        {
            DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("en-US").DateTimeFormat;
            DataTable dt = new DataTable();
            DataRow row;
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("Year", typeof(string));
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Occupation", typeof(string));
            for(day = CalFrom.Date; day <= CalTo; day = day.AddDays(1))
            {
                var Q = db.Reservas.Where(c => c.CheckIn <= day && c.CheckOut > day && c.Cancelado == false);
                string MyMonth = dtfi.GetMonthName(day.Month).ToString();
                row = dt.NewRow();
                row["No"] = dt.Rows.Count + 1;
                row["Year"] = day.Year.ToString();
                row["Month"] = MyMonth;
                row["Date"] = day.ToString("dd/MM/yyyy");
                row["Occupation"] = Q.Count();
                dt.Rows.Add(row);
            }
            return dt;
        }
        public DateTime day { get; set; }
        public DateTime CalFrom
        {
            get
            {
                return DpFrom.Value.Value;
            }
        }
        public DateTime CalTo
        {
            get
            {
                return DpTo.Value.Value;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = DoGrid();
            GridView1.DataBind();
        }
    }
