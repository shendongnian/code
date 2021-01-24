    private void GetDataSetFromCSV() {
      StatesDataSet = new DataSet("States");
      DataTable dt = new DataTable("States");
      dt.Columns.Add("StateName", typeof(string));
      dt.Columns.Add("ShortName", typeof(string));
      StreamReader sr = new StreamReader(@"D:\Test\States.txt");
      string curLine = "";
      string[] splitArray;
      while ((curLine = sr.ReadLine()) != null) {
        splitArray = curLine.Split(',');
        if (splitArray.Length >= 2) {
          dt.Rows.Add(splitArray[0], splitArray[1]);
        }
        else {
          MessageBox.Show("array less than 3: " + curLine);
        }
      }
      StatesDataSet.Tables.Add(dt);
      dt = new DataTable("Cities");
      dt.Columns.Add("City", typeof(string));
      dt.Columns.Add("ShortName", typeof(string));
      sr.Close();
      sr = new StreamReader(@"D:\Test\Cities.csv");
      while ((curLine = sr.ReadLine()) != null) {
        splitArray = curLine.Split(',');
        if (splitArray.Length >= 2) {
          dt.Rows.Add(splitArray[0], splitArray[1]);
        }
        else {
          MessageBox.Show("Less than 3: " + curLine);
        }
      }
      sr.Close();
      StatesDataSet.Tables.Add(dt);
    }
 
