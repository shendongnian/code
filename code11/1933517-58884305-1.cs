    private void OpenSimilarDocuments(Project _project)
    {
        Dispatcher.VerifyAccess();
        if (_project == null)
        {
            return;
        }
        // Traverse all ProjectItems of the project
        if (_project.ProjectItems != null)
        {
            foreach (ProjectItem item in _project.ProjectItems)
            {
                OpenSimilarDocuments(item);
            }
        }
    }
    private void OpenSimilarDocuments(ProjectItem _item)
    {
        Dispatcher.VerifyAccess();
        if (_item == null)
        {
            return;
        }
        // See if it is a file we want to open
        if (_item.Name != null)
        {
            string name = _item.Name.Contains(".") ? _item.Name.Substring(0, _item.Name.IndexOf('.')) : _item.Name;
            if (string.Compare(StrName, name, true) == 0 && !_item.IsOpen)
            {
                _item.Open();
            }
        }
        // Traverse all child ProjectItems
        if (_item.ProjectItems != null)
        {
            foreach (ProjectItem item in _item.ProjectItems)
            {
                OpenSimilarDocuments(item);
            }
        }
        // See if we have a child project and traverse that as well
        if (_item.SubProject != null)
        {
            OpenSimilarDocuments(_item.SubProject);
        }
    }
