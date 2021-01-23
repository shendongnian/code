       this.Controls.Cast<Control>()
            .Where(ctl => ctl is TextBox).Cast<TextBox>().ToList()
            .ForEach(e => e.ReadOnly = true);
        
        this.Controls.Cast<Control>()
            .Where(ctl => ctl is DataGridView).Cast<DataGridView>().ToList()
            .ForEach(e => e.ReadOnly = true);
