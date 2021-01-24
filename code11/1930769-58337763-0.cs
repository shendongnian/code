    [System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, false)]
    public WebControlling.ProjectsOverallDataTable GetProjectsOverallByAttributes(Guid CountryID, Guid OrganisationUnitID, Int32 ProjectYear)
    {
        if (CountryID == null || OrganisationUnitID == null || ProjectYear == 0)
            return new WebControlling.ProjectsOverallDataTable();
        return Adapter.GetProjectsByAttribute(CountryID, OrganisationUnitID, ProjectYear);
    }
