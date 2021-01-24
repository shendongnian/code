    public Newdatagrid()
    {
        InitializeComponent();
        //Do datatable
        ds = new DataSet();
        dt = new DataTable();
        dt.Columns.Add("Bus Model", typeof(string));//0
        dt.Columns.Add("Bus Type", typeof(string));//1
        dt.Columns.Add("Mileage", typeof(string));//2
        if (Savestate.vehnochange_list.Count > 0)
        {
            for (int i=0; i < Savestate.vehnochange_list.Count; ++i)
            {
                DataRow dr = dt.NewRow();
                dr["Bus Model"] = Savestate.busmodel_list[i];//0
                dr["Bus Type"] = Savestate.bustype_list[i];//1
                dr["Mileage"] = Savestate.busmileage_list[i];//2
                dt.Rows.Add(dr);
            }
            this.dataGridView2.DataSource = dt;
        }
    }
