    private void ActiveDocumentChanged(object sender, DocumentChangedEventArgs e)
    {
        var timelinePane = 
             (TimelinePane)WindowService.PaletteRegistry["Designer_TimelinePane"].Content;
        _activeSceneViewModel = timelinePane.ActiveSceneViewModel;
        _activeSceneViewModel.ElementSelectionSet.Changed += 
             new System.EventHandler(ElementSelectionSet_Changed);
        //some other goes here....
    }
    
    void ElementSelectionSet_Changed(object sender, System.EventArgs e)
    {
        SceneElementSelectionSet selectionSet 
            = sender as SceneElementSelectionSet;
        // get the selected elements from the selection set
    }
