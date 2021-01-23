    DataSet ds1 = new DataSet();
            ds1.Tables.Add(m_DataLayer.GetRealA_Data(X, Y).Copy()); Returns Table ["A"]
            ds1.Tables.Add(m_DataLayer.GetB_Empty().Copy());// Returns Table ["B"]
            ds1.Tables.Add(m_DataLayer.GetC_Empty().Copy());// Returns Table ["C"]
            ds1.Tables.Add(m_DataLayer.GetD_Empty().Copy());// Returns Table ["D"]
            ds1.Relations.Add("b", ds1.Tables["A"].Columns["A_id"], ds1.Tables["B"].Columns["A_id"]);
            ds1.Relations.Add("c", ds1.Tables["B"].Columns["B_id"]
                , ds1.Tables["C"].Columns["B_id"]);
            ds1.Relations.Add("d", ds1.Tables["C"].Columns["C_id"]
                , ds1.Tables["D"].Columns["D_id"]);
            dt_TheGridViewDataSet = ds1;
            TheGridView.DataSource = ds1;
