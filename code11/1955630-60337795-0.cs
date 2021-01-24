    private void GridView_ShownEditor(object sender, EventArgs e)
    {
        GridView view = sender as GridView;
        if (view.ActiveEditor is TextEdit)
            view.ActiveEditor.MouseUp += ActiveEditor_MouseUp;
    }
    
    private void ActiveEditor_MouseUp(object sender, MouseEventArgs e)
    {
        BaseEdit edit = sender as BaseEdit;
        edit.MouseUp -= ActiveEditor_MouseUp;
        edit.SelectAll();
    }
