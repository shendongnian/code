    private DataGridView dgview;
    private DataGridViewTextBoxColumn dgviewcol1;
    private DataGridViewTextBoxColumn dgviewcol2;
    void Search()
    {
        dgview = new DataGridView();
        dgviewcol1 = new DataGridViewTextBoxColumn();
        dgviewcol2 = new DataGridViewTextBoxColumn();
        this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewTextBoxColumn[] {this.dgviewcol1, this.dgviewcol2}); // "cannot implicitly convert type system.windows.forms.datagridtextboxcolumn to system.windows.forms.datagridviewcolumn"
        dataGridView2.Visible = false;
        this.dgviewcol1.Visible = false; // Visible property doesn't exist in datagridviewtextboxcolumn
        this.dgviewcol2.Visible = false;
        this.Controls.Add(dgview);
        this.dgview.ReadOnly = true;
        dgview.BringToFront();
    }
