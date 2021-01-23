    //load entities to the combo box
    ProjectEntities projectE = new ProjectEntities();
    var pdata = projectE.Projects;
    cbProjects.DataSource = pdata; //cbProjects.ItemsSource
    cbProjects.DisplayMember = "Name"; //cbProjects.DisplayMemberPath
    
    //get selected value
    var item = cbProjects.SelectedItem as Project;
    int projectID = item.ProjectID;
