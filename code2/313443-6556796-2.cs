    public void CopyFrom(UserControl control)
    {
        using (var source = control as UserControl1)
        {
            if (source == null)
            {
                return;
            }
            // copy properties
            this.checkBox1.Checked= source.checkBox1.Checked;
        }
    }
