        private void populateCombos()
        {
        string GetConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = c:\\Data\\Db\\Comp.mdb";
        string queryString = "SELECT DISTINCT DC FROM Comp";
        OleDbDataAdapter dA = new OleDbDataAdapter(queryString, GetConn1);
        DataTable dC = new DataTable();
        dA.Fill(dC);
        comboBoxDC.DataSource = dC;
        comboBoxDC.DisplayMember = "DC";
        comboBoxDC.ValueMember = "DC"; --Add this line.
        string GetConn2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = c:\\Data\\Db\\Comp.mdb";
        string queryString2 = "SELECT DISTINCT PL FROM Comp";
        OleDbDataAdapter dA2 = new OleDbDataAdapter(queryString2, GetConn2);
        DataTable pL = new DataTable();
        dA2.Fill(pL);
        comboBoxPL.DataSource = pL;
        comboBoxPL.DisplayMember = "PL";
        comboBoxPL.ValueMember = "PL"; --Add this line, too.
    }
