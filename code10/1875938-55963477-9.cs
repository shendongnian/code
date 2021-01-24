    private void Form1_Load(object sender, EventArgs e) {
      List<Work> ListOfWork = new List<Work>();
      FillListOfWork(ListOfWork);
      dataGridView1.Columns.Add(GetComboColumn(ListOfWork));
      dataGridView1.DataSource = ListOfWork;
    }
    private void FillListOfWork(List<Work> ListOfWork) {
      Work newWork;
      Random rand = new Random();
      for (int i = 0; i < 100; i++) {
        newWork = new Work();
        newWork.WorkID = i;
        newWork.WorkName = "Work Name " + i;
        newWork.WorkStatus = rand.Next(1, 5);
        newWork.DateCreated = DateTime.Now;
        newWork.DateModified = DateTime.Now;
        ListOfWork.Add(newWork);
      }
    }
    private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      MessageBox.Show("DataError: " + e.Exception.Message);
    }
