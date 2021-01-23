    public bool EditorTabVisible{
        get{
            return GetActiveWorkspace() is EditorTabViewModel;
        }
    }
