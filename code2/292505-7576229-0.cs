        [TestMethod]
        [HostType("Moles")]
        public void IsolatedSqlDataAdaptorTestWithFill()
        {
            // Arrange
            MSqlConnection.AllInstances.Open = c => { };
            MSqlConnection.AllInstances.Close = c => { };
            MSqlDataAdapter.ConstructorStringSqlConnection = (@this, cmd, conn) => { };
            MDbDataAdapter.AllInstances.FillDataSetString = (da, ds, s) =>
                {
                    var dt = new DataTable(s);
                    dt.Columns.Add(new DataColumn("string", typeof(string)));
                    dt.Columns.Add(new DataColumn("int", typeof(int)));
                    dt.Rows.Add("field", 5);
                    ds.Tables.Add(dt);
                    return 1;
                };
            // Act
            using (var dset = new DataSet())
            {
                using (var conn = new SqlConnection())
                {
                    using (var da = new SqlDataAdapter("select something from aTable", conn))
                    {
                        da.Fill(dset, "aTable");
                    }
                }
                // Assert
                Assert.AreEqual(1, dset.Tables[0].Rows.Count, "Count");
                Assert.AreEqual("field", dset.Tables[0].Rows[0]["string"], "string");
                Assert.AreEqual(5, dset.Tables[0].Rows[0]["int"], "int");
            }
        }
