    @model IEnumerable<Project>
    
    @foreach (Project project in Model)
    {
        <div>
            @foreach (Project subProject in project.SubProjects)
            {
                <span>subProject.Name</span>
            }
        </div>
    }
