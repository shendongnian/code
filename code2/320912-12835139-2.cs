    public VisualState GetCurrentState(string stateGroupName)
    {
        VisualStateGroup stateGroup1 = null;
    
        IList<VisualStateGroup> list = VisualStateManager.GetVisualStateGroups(VisualTreeHelper.GetChild(this, 0) as FrameworkElement);
    
        foreach (var v in list)
            if (v.Name == stateGroupName)
            {
                stateGroup1 = v;
                break;
            }
    
        return stateGroup1.CurrentState;
    }
