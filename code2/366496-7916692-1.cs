    <UserControl.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="../Resources/RFPModuleResources.xaml" />
            <ResourceDictionary>
                <DataTemplate x:Key="SaveButton" DataType="{x:Type vm:UC2002_RFPBeheren_ViewModel}">
                    <Button Command="{Binding SaveRFPCommand}">Save</Button>
                </DataTemplate>
            </ResourceDictionary>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
    </UserControl.Resources>
    <UserControl.DataContext>
       <x:local VMFoo/>
    </UserControl.DataContext>
    <StackPanel HorizontalAlignment="Right" Orientation="Horizontal">
       <ContentControl Content="{Binding MySaveVM}"/>
       <Button Command="{Binding CloseTabCommand}">Close</Button>
    </StackPanel>
