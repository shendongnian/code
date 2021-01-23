    // Deserialize UI controllers from configuration files
    // Each controller should act as view-model for its UI elements
    
    // Register controllers with UI Manager
    foreach controller in config.UiControllers uiManager.AddController(controller);
    
    void UiManager.AddController(UiController controller)
    {
        // Load controller's tool windows
        foreach toolWindow in contoller.toolWindows
        {
             toolWindow.LoadResources();
             toolWindow.DataContext = controller;
             mainWindow.AddToolWindow(toolWindow, contoller.PreferedUiRegion);
        }
    
        // Load controller's toolbars
        foreach toolBar in controller.ToolBars
        {
             toolBar.DataContext = controller;
             mainWindow.AddToolBar(toolBar);
        }
    
        // Load controller's contextual toolbar groups
        foreach group in controller.ContextualToolBarGroups
        {
             group.DataContext = controller;
             mainWindow.AddContextualToolBarGroupr(group);
        }
    
        // Load view models for specific model types
        foreach item in controller.ViewModelsDictionary
        {
             this.RegisterViewModelType(item.ModelType, item.ViewModelType, item.ViewType);
        }
    }
    void UiManager.OnItemSelected(Object selectedItem)
    {
        var viewModelType = GetViewModelTypeFromDictionary(selectedItem);
        var viewType = GetViewTypeFromDictionary(selectedItem) ?? typeof(ContentPresentor);
    
        var viewModel = Reflect.CreateObject(viewModelType);
        var view = Reflection.CreateObject(viewType);
    
        viewModel.Model = selectItem;
        view.DataContext = viewModel;
    
        // Enable activation of contextual tab group on activate of view (if user clicks on it)
        view.OnActivatedCommandParameter = viewModel.ContextualTabGroupName;
    
        // This command should ask mainWindow to find contextual tab group, by name, and activate it
        view.OnActivatedCommand = ModelActivatedCommand;
    
        mainWindow.DocumentArea.Content = view;
    }
