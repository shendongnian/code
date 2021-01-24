    private void LabelPos32A_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(Label))) e.Effect = DragDropEffects.Move;
    }
    private void LabelPos32A_DragDrop(object sender, DragEventArgs e)
    {
        var ob2 = sender as Label;
        var ob1 = (Label)e.Data.GetData(typeof(Label));
        string s2 = ob2.Text;
        ob2.Text = ob1.Text;
        ob1.Text = s2;
    }
    private void LabelPos25_MouseDown_1(object sender, MouseEventArgs e)
    {
        var ob = sender as Label;
        DoDragDrop(ob, DragDropEffects.Move);
    }
