        public void SaveWithManager()
        {
        DataSet1TableAdapters.TableAdapterManager mgr1 = new DataSet1TableAdapters.TableAdapterManager();
        DataSet1TableAdapters.Table1TableAdapter taTbl1 = new DataSet1TableAdapters.Table1TableAdapter();
        DataSet1TableAdapters.Table2TableAdapter taTbl2 = new DataSet1TableAdapters.Table2TableAdapter();
        mgr1.Table1TableAdapter = taTbl1;
        mgr1.Table2TableAdapter = taTbl2;
        mgr1.UpdateOrder = DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete; 
        mgr1.UpdateAll(your dataset);
    } 
