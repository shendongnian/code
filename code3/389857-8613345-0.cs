    string _seperator1 = "-------------------------------------------------------------------------------------------------------------------------------- \n"; 
    string isbn = _tbIsbnSuche.Text;
    DataView custView = new DataView(_dset.Tables["Book"], "", "ISBN", DataViewRowState.CurrentRows);
    {
        _lBdatenOutput.Items.Clear(); //Delete existing Objects from the Output
        foreach (DataRowView myDRV in custView)
        {
            DataRow dr = myDRV.Row;
            if((dr["ISBN"].ToString().IndexOf(isbn) >= 0))
            {
                foreach (DataColumn cl in custView.Table.Columns)
                {
                    _lBdatenOutput.Items.Add("Spalten-Name:  " + " \t " + cl.ColumnName + " \t" + dr[cl]);
                }
                _lBdatenOutput.Items.Add(_seperator1); //Insert a seperator
            }
        }
    }
