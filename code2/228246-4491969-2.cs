       public void  savewithTransacition()
        {
            DataSet1TableAdapters.Table1TableAdapter taTbl1 = new DataSet1TableAdapters.Table1TableAdapter();
            DataSet1TableAdapters.Table2TableAdapter taTbl2 = new DataSet1TableAdapters.Table2TableAdapter();
            SqlTransaction st = null;
            SqlConnection sc = new SqlConnection("ur conneciton string");
            try
            {
                sc.Open();
                st = sc.BeginTransaction();
                taTbl1.Transaction = st;
                taTbl2.Transaction = st;
                st.Commit();
            }
            catch (System.Exception ex)
            {
                st.Rollback();
                throw ex;
            }
        }
