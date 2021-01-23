        protected override void OnUserDeletingRow(DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Tag != null && e.Row.Tag.ToString().Equals("Separator"))
            {
                e.Cancel = true;
                return;
            }
            base.OnUserDeletingRow(e);
        }
