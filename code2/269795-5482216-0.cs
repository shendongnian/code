    public class ProjectListForm : Form
    {
        ...
        public ListView.ListViewItemCollection ProjectsListViewItems
        {
            get { return ListViewProjects.Items; }
        }
    }
