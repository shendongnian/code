    DataTable dt = new DataTable();
                dt.Columns.Add("ColA", typeof(int));
                dt.Columns.Add("ColB", typeof(string));
                dt.AcceptChanges();
    
                var r1 = dt.NewRow();
                r1["ColA"] = 1;
                r1["ColB"] = "OneThree";
                dt.Rows.Add(r1);
    
                var r2 = dt.NewRow();
                r2["ColA"] = 2;
                r2["ColB"] = "FourTwo";
                dt.Rows.Add(r2);
    
                var r3 = dt.NewRow();
                r3["ColA"] = 3;
                r3["ColB"] = "EightNine";
                dt.Rows.Add(r3);
    
                var r4 = dt.NewRow();
                r4["ColA"] = 4;
                r4["ColB"] = "ThreeEightFive";
                dt.Rows.Add(r4);
    
                var r5 = dt.NewRow();
                r5["ColA"] = 5;
                r5["ColB"] = "SevenNine";
                dt.Rows.Add(r5);
    
                dt.AcceptChanges();
    
                var subArray = new string[3] { "Two", "Eight", "Three" };
    
                var query = from r in dt.AsEnumerable()
                            where  subArray.Any(s=> r.Field<string>("ColB").IndexOf(s,StringComparison.InvariantCultureIgnoreCase)>-1)
                            select r.Field<string>("ColB");
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
