    foreach (Control control in this.Controls)
    
        {
            if(control is GroupBox)
            {
            foreach (Control ctrl in groupBox1.Controls)
                        {
                            if (ctrl is TextBox)
                            {
                                MessageBox.Show(ctrl.Name);
                            }
                        }
            }
        {
