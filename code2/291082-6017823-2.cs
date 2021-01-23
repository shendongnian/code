    protected void Btn_AddCol_Click(object sender, EventArgs e)
    {
        TemplateField tf = new TemplateField();
        tf.HeaderTemplate = new GridViewLabelTemplate(DataControlRowType.Header, "Col1", "Int32");
        tf.ItemTemplate = new GridViewLabelTemplate(DataControlRowType.DataRow, "Col1", "Int32");
        MyGridView.Columns.Add(tf);
    }
