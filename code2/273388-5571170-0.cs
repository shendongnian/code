    static BindingSource jp2bindingSource = new BindingSource();
    void jp2FillCombo() {
      ComboBox comboBox1 = new ComboBox();
      comboBox1.Items.Clear();
      object[] objs = jp2Databind(new DataSet(), "Table1", "Column1", true);
      comboBox1.Items.AddRange(objs);
    }
    static object[] jp2Databind(DataSet dataset, string tableName, string columnName, bool unique) {
      jp2bindingSource.DataSource = dataset;
      jp2bindingSource.DataMember = tableName;
      List<string> itemTypes = new List<string>();
      foreach (DataRow r in dataset.Tables[tableName].Rows) {
        try {
          object typ = r[columnName];
          if ((typ != null) && (typ != DBNull.Value)) {
            string strTyp = typ.ToString().Trim();
            if (!String.IsNullOrEmpty(strTyp)) {
              if (unique) {
                if (!itemTypes.Contains(strTyp)) {
                  itemTypes.Add(strTyp);
                }
              } else {
                itemTypes.Add(strTyp);
              }
            }
          }
        } catch (Exception err) {
          Global.LogError("Databind", err);
        }
      }
      try {
        itemTypes.Sort();
      } catch (Exception err) {
        Console.WriteLine(err.Message);
      }
      return itemTypes.ToArray();
    }
