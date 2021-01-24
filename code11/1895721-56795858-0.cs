           public void CreateTableReport()
            {
                DataColumn[] colsMerge ={
                          new DataColumn("wID",typeof(String)),
                          new DataColumn("username",typeof(String)),
                          new DataColumn("fname",typeof(String)),
                          new DataColumn("lastname",typeof(String)),
                          new DataColumn("email",typeof(String)),
                          new DataColumn("empid",typeof(String)),
                          new DataColumn("lastlogintime",typeof(String)),
                          new DataColumn("UserID",typeof(String)),
                          new DataColumn("Alias",typeof(String)),
                          new DataColumn("UserType",typeof(String)),
                          new DataColumn("AccountStatus",typeof(String)),
                          new DataColumn("ChgPasswdNxtLogin",typeof(String)),
                      };
                Table_MergeUserData.Columns.AddRange(colsMerge);
                var mergedData = (from s in Table_SalesUserData.AsEnumerable()
                                  join w in Table_WifiUserData.AsEnumerable() on s.Field<string>("UserID") equals w.Field<string>("wID")
                                  select new { sales = s, wifi = w }).ToList();
                foreach (var data in mergedData)
                {
                    Table_MergeUserData.Rows.Add(new object[] {
                        data.sales.Field<string>("wID")
                    });
                }
            }
