    public class MainWindowViewModel  : Conductor<IScreen>.Collection.OneActive
    {
        public void LoadAddNewTask() => this.ActivateItemAsync(new AddNewTaskViewModel());
        public void LoadAddNewProject() => this.ActivateItemAsync(new AddNewProjectViewModel());
    }
