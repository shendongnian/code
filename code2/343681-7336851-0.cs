    protected void SetGenericBoxVisibility(Action<Project> propertySetter,
                                           Action<bool> panelShower,
                                           bool boxVisibility)
    {
        Project project = LoadProject();
        propertySetter(project);
        ReDrawSomeThings();
        CalculateSomeStuff();
        Project.UpdateBoxStatus();
        SaveProject(project);
        panelShower();
        RaiseStatusUpdated();
    }
