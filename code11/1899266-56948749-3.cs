    <ResourceDictionary>    
        <ObjectDataProvider x:Key="ViewModelProvider" ObjectType="{x:Type local:NotifyIconViewModel}">
            <ObjectDataProvider.ConstructorParameters>
                <interface:ServiceControllerWorker />
            </ObjectDataProvider.ConstructorParameters>
        </ObjectDataProvider>
    </ResourceDictionary>
    
    <tb:TaskbarIcon DataContext="{StaticResource ViewModelProvider}" />
