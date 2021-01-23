            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    Method1Save(); //DB
                    Method2Save(); //EMS1
                    Method3Save(); //EMS2
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem " + ex.ToString());
            }
