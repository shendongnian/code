            try
            {
                using (var tx = connection.BeginTransaction())
                {
                    DoWork1();
                    DoWork2();
                    DoWork3();
                    tx.Commit();
                }
            }
            catch (DataException ex)
            {
                // log ex
            }
