            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ProductName"));
            foreach (var propNo in values.Select(v => v.PropertyNo).Distinct())
            {
                dt.Columns.Add(
                    new DataColumn(properties.Where(p => p.PropertyNo == propNo).First().PropertyName));
            }
            foreach (var prodNo in  values.Select(v => v.ProductNo).Distinct())
            {
                Product  prod = products.Where(p => p.ProductNo == prodNo).First();
                DataRow dr = dt.NewRow();
                dr["ProductName"] = prod.ProductName;
                foreach (var value in values.Where(v => v.ProductNo == prodNo))
                {
                    Property prop = properties.Where(p => p.PropertyNo == value.PropertyNo).First();
                    dr[prop.PropertyName] = value.Value;
                }
            }
