            DataTable datatbl = new DataTable();
            datatbl.Columns.Add(new DataColumn("description",typeof(string)));
            // add simple test rows
            datatbl.Rows.Add("I'm feeling lucky today.");
            datatbl.Rows.Add("I'm feeling bad today.");
            datatbl.Rows.Add("I'm feeling good today.");
            // more test rows here...
            List<string> lst = new List<string>(new string[] { "Lucky", "bad", "ok" });
            var item =
                from a in datatbl.AsEnumerable()
                from b in lst
                where a.Field<string>("description").ToUpper.Contains(b.ToUpper())
                select a;
            var item2 =
                from a in datatbl.AsEnumerable()
                where lst.Any(x => a.Field<string>("description").ToUpper().Contains(x.ToUpper()))
                select a;
