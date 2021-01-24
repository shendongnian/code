`
void PopulateProjects()
{
    radProjList.SelectedIndexChanged -= radProjList_SelectedIndexChanged;
    radProjList.Visible = true;
    radTaskList.Visible = false;
    radProjList.Items.Clear();
    radProjList.Text = "Select Project";
    List<string> ProjectName = new List<string>();
    ProjectName.Add("abc");
    ProjectName.Add("def");
    ProjectName.Add("ghi");
    ProjectName.Add("jkl");
    ProjectName.Add("mno");
    ProjectName.Add("pqr");
    
    radProjList.DataSource = ProjectName;
    radProjList.DisplayMember = "ProjectName";
    radProjList.ValueMember = "ProjectName";
    radProjList.AutoCompleteDataSource = ProjectName;
    
    Size popupSize = new Size(400, 300);
    
    radProjList.DropDownListElement.DropDownMinSize = popupSize;
    radProjList.ListElement.Font = new Font("Microsoft Sans Serif", 16);
    radProjList.SelectedIndex = -1;
    radProjList.Text = "Select Project";
    radProjList.SelectedIndexChanged += radProjList_SelectedIndexChanged;
}
void PopulateTasks()
{
    radTaskList.SelectedIndexChanged -= radTaskList_SelectedIndexChanged;
    List<string> populateTaskList = new List<string>();
    radTaskList.Visible = true;
    radTaskList.Items.Clear();
    populateTaskList.Add("task one");
    populateTaskList.Add("task two");
    populateTaskList.Add("task three");
    populateTaskList.Add("task four");
    populateTaskList.Add("task five");
    populateTaskList.Add("task six");
    radTaskList.Items.Clear();
    radTaskList.Text = "Select Tasks";
  
    radTaskList.DataSource = populateTaskList;
    radTaskList.DisplayMember = "projectTask";
    radTaskList.ValueMember = "projectTask";
    radTaskList.AutoCompleteDataSource = populateTaskList;
    radTaskList.AutoCompleteMode = AutoCompleteMode.Suggest;
    Size popupSize = new Size(400, 300);
    radTaskList.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownMinSize = popupSize;
    radTaskList.DropDownListElement.DropDownMinSize = popupSize;
    radTaskList.DropDownListElement.AutoCompleteSuggest.DropDownList.ListElement.VisualItemFormatting += new Telerik.WinControls.UI.VisualListItemFormattingEventHandler(ListElement_VisualItemFormatting);
    radTaskList.ListElement.Font = new Font("Microsoft Sans Serif", 16);
   
    radTaskList.SelectedIndex = -1;
    radTaskList.Text = "Select Project Type";
    radTaskList.SelectedIndexChanged += radTaskList_SelectedIndexChanged;
}
`
I hope this helps. 
