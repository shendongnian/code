    private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
    {
        // Get the type of exception
        if (e.Exception.GetType() == typeof(ConstraintException))
        {
            // Get the unique constraint column
            using (DataColumn constraintColumn = ((UniqueConstraint)dtDetail.Constraints[0]).Columns[0])
            {
                // Get the value that violates unique constraint
                object value = ((DataRowView)e.Row).Row[constraintColumn];
    
                DialogResult dr = XtraMessageBox.Show(string.Format("Kolom {0} diatur sebagai Unique. Nilai {1} telah ada sebelumnya. Apakah Anda ingin memperbaiki barisnya?", constraintColumn.ColumnName, value.ToString()), "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    
                if (dr == DialogResult.Yes)
                {
                    // No action. User can correct their input.
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                }
                else
                {
                    // Duplicate row will be removed
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
                }
            }
        }
    }
