    public bool Tab1Visible{
        get{
            return GetActiveTab() is EditorTabViewModel;
        }
    }
