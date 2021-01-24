    private void radListView1_MouseDown(object sender, MouseEventArgs e)
    {
        int index = radListView1.IndexFromPoint(e.Location);
        radListView1.SelectedIndex = index;
        testName = radListView1.Items[index].ToString();
    }
    private void rListCtrl_DragDrop(object sender, DragEventArgs e){
    {
        MessageBox.Show(testName);
    }
