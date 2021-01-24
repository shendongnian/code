    <TreeView DataContext="{Binding}">
        <TreeView.Resources>
             <ResourceDictionary>
                 <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="pack://application:,,,/OldDataTemplate.xaml"/>
                 </ResourceDictionary.MergedDictionaries>
                 <DataTemplate DataType="{x:Type local:MyContentClass1}" >
                     <ContentPresenter Content="{Binding}" 
                         ContentTemplate="{DynamicResource MyTemplate1}" />
                 </DataTemplate>
                 <DataTemplate DataType="{x:Type local:MyContentClass2}" >
                     <ContentPresenter Content="{Binding}" 
                          ContentTemplate="{DynamicResource MyTemplate2}" />
                 </DataTemplate>
             </ResourceDictionary>
        </TreeView.Resources>
    </TreeView>
