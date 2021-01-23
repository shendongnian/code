    public void deleteRow(DataRow selectedRow)
            {
                foreach (DataRow  in StudentTable.Rows)
                {
                    if (SR[TableColumn.StudentID.ToString()].ToString() == StudentIndex)
                        SR.Delete();
                }
    
                StudentTable.AcceptChanges();
            }
