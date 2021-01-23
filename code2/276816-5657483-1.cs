    protected void lit1_DataBinding(object sender, System.EventArgs e)
    {
        Literal lit = (Literal)(sender);
        lit.Text = ((bool)(Eval("Column1")) ?
            Eval("Column2").ToString() : Eval("Column3").ToString();
    }
