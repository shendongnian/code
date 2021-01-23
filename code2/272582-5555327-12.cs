        private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StudentSorter sorter = null;
            string column = dGV.Columns[e.ColumnIndex].DataPropertyName; //Use column name if you set it
            if (column == "StudentId")
            {
                sorter = new StudentSorter(StudentSorter.SField.StudentId, SetOrderDirection(column));
            }
            else if (column == "Name")
            {
                sorter = new StudentSorter(StudentSorter.SField.Name, SetOrderDirection(column));
            }
            
            ...
            List<Student> lstFD = datagridview.DataSource as List<Student>;
            lstFD.Sort(sorter);
            datagridview.DataSource = lstFD;
            datagridview.Refresh();
        }
        
