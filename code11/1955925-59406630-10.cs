    <TreeView x:Name="MainTreeView">
      <TreeView.DataContext>
        <MainViewModel />
      </TreeView.DataContext>
    </TreeView>
    <Button Content="{Binding NameE}" 
            CommandParameter="{Binding NameE}" 
            Command="{Binding ElementName=MainTreeView, Path=DataContext.FirstViewModel.FirstCommand}" />
    
    <Button Content="{Binding NameD}" 
            CommandParameter="{Binding NameD}" 
            Command="{Binding ElementName=MainTreeView, Path=DataContext.SecondViewModel.SecondCommand}" />
