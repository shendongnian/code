    private void _fillDataTable() {
      int batchToInsert = 1000000;
      int numberOfTimes = 10;
      int recordCounter = 1;
      for (int i = 0; i < numberOfTimes; ++i) {
        for (int j = 0; j < batchToInsert; j++) {
          var row = dt.NewRow();
          row[0] = string.Format("TestName{0}", recordCounter);
          row[1] = (decimal) i;
          row[2] = string.Format("NonNumericResult{0}", recordCounter);
          row[3] = i;
          dt.Rows.Add(row);
          recordCounter += 1;
        }
        _insertData();
        dt.Clear();
      }
    }
