        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            base.OnEditingControlShowing(e);
            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = e.Control as DataGridViewComboBoxEditingControl;
            if (dataGridViewComboBoxEditingControl != null)
            {
                dataGridViewComboBoxEditingControl.GotFocus += this.DataGridViewComboBoxEditingControl_GotFocus;
                dataGridViewComboBoxEditingControl.Disposed += this.DataGridViewComboBoxEditingControl_Disposed;
            }
        }
        private void DataGridViewComboBoxEditingControl_GotFocus(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                if (!comboBox.DroppedDown)
                {
                    comboBox.DroppedDown = true;
                }
            }
        }
        private void DataGridViewComboBoxEditingControl_Disposed(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.GotFocus -= this.DataGridViewComboBoxEditingControl_GotFocus;
                control.Disposed -= this.DataGridViewComboBoxEditingControl_Disposed;
            }
        }
