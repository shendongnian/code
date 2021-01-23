    List<Path> pathList;
    public Page() // constructor
    {
        InitializeComponent();
        pathList = new List<Path>();
        pathList.Add(Path1);
        // and so forth
    }
    // Call this function when you want to change the state
    private void ActivatePath(Path p)
    {
        foreach (Path listItem in pathList)
        {
            // If the item from the list is the one you want to activate...
            if (listItem == p)
                VisualStateManager.GoToState(listItem, "Activate", true);
            // otherwise...
            else
                VisualStateManager.GoToState(listItem, "Deactivate", true);
        }
    }
