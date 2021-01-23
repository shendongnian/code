    repeater.DataSource = getResults()
        .Select(q => new {
            name = q.name,
            enddate = GetEndDate(q)});
        private void GetEndDate(TypeOfQ q)
        {
           return (q.EndDate.HasValue) ? q.EndDate.ToString() : "Present";
        }
