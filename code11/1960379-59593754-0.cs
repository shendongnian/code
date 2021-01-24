            DataTable dtTemp = new DataTable();
            dtTemp = dtOri.Clone();
            dtTemp.Columns["WaitTime"].DataType = typeof(TimeSpan);
            dtTemp.Columns["AssistTime"].DataType = typeof(TimeSpan);
            //you can change data type to string as well if you need
            //if you are changing datatype to string make sure to add ".ToString()" in below code e.g secondsToTime(xx).ToString()
            foreach (DataRow row in dtOri.Rows)
            {
                dtTemp.Rows.Add(new object[] {row[0], secondsToTime(Convert.ToDouble(row[1].ToString())), secondsToTime(Convert.ToDouble(row[2].ToString())), row[3],row[4],row[5]});
            }
            dtOri = dtTemp;
