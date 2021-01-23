    private void myDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        if (e.ColumnIndex == 3)
        {
            // _appointments is a member variable which is the datasource of the grid
            Appointment appointment = _appointments[e.RowIndex];
            IList<DisciplineType> disciplines = appointment.GetDisciplines();
            
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (i > 0)
                    e.Value += ", " + disciplines[i].Description;
                else
                    e.Value += disciplines[i].Description;
            }
        }
    }
