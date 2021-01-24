    private delegate List<ListViewItem> dlgGetSelectedJobs();
    private List<ListViewItem> GetSelectedJobs()
    {
        if(listViewJobViewer.InvokeRequired)
        {
            var dlg = new dlgGetSelectedJobs(GetSelectedJobs);
            return listViewJobViewer.Invoke(dlg) as List<ListViewItem>;
        }
        return (from ListViewItem i in listViewJobViewer.SelectedItems select i).ToList();
    }
