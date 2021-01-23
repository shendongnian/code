            int userId = Convert.ToInt32(TestContext.DataRow[0].ToString());
            int connId = Convert.ToInt32(TestContext.DataRow[1].ToString());
            string xml = TestHelper.GetDataFromDb(userId, connId);
            var rows = xml.Split('\n');
            Parallel.ForEach(rows, (row) =>
            {
                var a = doStuffOnRowA(row);
                var b = doStuffOnRowB(row);
                Assert.AreEqual(a, b);
            });
