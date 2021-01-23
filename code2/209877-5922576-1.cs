    private void dgvFechas_ColumnAdded(object sender, DataGridViewColumnEventArgs e) {
     try {
       //Evalua si el tipo de dato es DateTime.
       if(e.Column.ValueType == typeof(DateTime)) {
            e.Column.CellTemplate = new CalendarCell();
       } 
     }
     catch(Exception ex) { }
    }
