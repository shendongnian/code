        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            CheckBox chkbx = GetTemplateChild("PART_CheckBox") as CheckBox;
            chkbx.Checked += Chkbx_Checked;
        }
        private void Chkbx_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Event Raised");
        }
        ...
