    private DataGridViewComboBoxColumn GetComboColumn(List<Work> listOfWork) {
      List<Status> ListOfStatus = GetStatusList(listOfWork);
      DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
      comboCol.Name = "Status";
      comboCol.DataPropertyName = "WorkStatus";
      comboCol.DisplayMember = "StatusString";
      comboCol.ValueMember = "StatusID";
      comboCol.DataSource = ListOfStatus;
      return comboCol;
    }
