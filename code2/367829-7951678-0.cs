     [Test]
        public void TestDataTable()
        {
            var dt = new DataTable();
            var f = typeof (DataTable).GetField("_compareFlags",
                                                System.Reflection.BindingFlags.NonPublic |
                                                System.Reflection.BindingFlags.Instance);
            var v = (System.Globalization.CompareOptions) f.GetValue(dt);
            f.SetValue(dt,  CompareOptions.OrdinalIgnoreCase);
            
            
            
            dt.Columns.Add("a", typeof(string));
            dt.Rows.Add("1");
            dt.Rows.Add("{");
            dt.Rows.Add("2");
            int i = 0;
            foreach (var val in dt.Select("", "a"))
            {
                Assert.AreEqual(new string[] {"1", "2", "{"}[i++],val["a"]);
            }
        }
