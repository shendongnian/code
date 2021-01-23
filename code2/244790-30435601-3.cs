            DataTable _DataTable = new DataTable();
            _DataTable.Columns.Add(new DataColumn("Col1"));
            _DataTable.Columns.Add(new DataColumn("Col2"));
            _DataTable.Columns.Add(new DataColumn("Col3"));
            for (int i = 0; i < 10; i++) {
                DataRow _DataRow = _DataTable.NewRow();
                _DataRow["Col1"] = (i + 1) + "Column 1";
                _DataRow["Col2"] = (i + 1) + "Column 2";
                _DataRow["Col3"] = (i + 1) + "Column 3";
                _DataTable.Rows.Add(_DataRow);
            }
            byte[] ByteArrayTest =  _DataTable.Serializer();
            DataTable dt = ByteArrayTest.Deserializer<DataTable>();
