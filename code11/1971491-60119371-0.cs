<DataGrid x:Name="RollTestDataGrid" SelectionUnit="Cell" ItemsSource="{Binding Shots, IsAsync=True}" SelectedIndex="{Binding SelectedShot, Mode=TwoWay}"  AutoGenerateColumns="False" HorizontalScrollBarVisibility="Auto" IsReadOnly="True" AreRowDetailsFrozen="True" HeadersVisibility="All" >
and...
<DataGrid.ContextMenu>
    <ContextMenu>
        <MenuItem Header="Toggle Visibility">
            <MenuItem Header="Show All" Name="ShowAllToggle" Click="ShowAllToggle_Click" />
            <MenuItem Header="Hide Selected" Name="HideSelectedButton" Click="HideSelectedButton_Click"/>
        </MenuItem>
    </ContextMenu>
</DataGrid.ContextMenu>
Choosing "Cell" for my SelectionUnit, gives me access to an element from which I can derive the associated Column. Then in code behind, I just iterate through these and switch their Visibility modes to collapsed.
In my .xaml.cs I have two "Click" methods.
private void ShowAllToggle_Click(object sender, RoutedEventArgs e)
{
    foreach (DataGridTextColumn col in RollTestDataGrid.Columns)
    {
        col.Visibility = Visibility.Visible;
    }
}
private void HideSelectedButton_Click(object sender, RoutedEventArgs e)
{
    foreach (DataGridCellInfo cell in RollTestDataGrid.SelectedCells)
    {
        cell.Column.Visibility = Visibility.Collapsed;
    }
}
I also have a "DeleteShot" method in the ViewModel, which is why my updated DataGrid .xaml has the addition of a Name and the IsAsync=True property in the ItemsSource.
x:Name="RollTestDataGrid" SelectionUnit="Cell" ItemsSource="{Binding Shots, IsAsync=True}" 
The IsAsync allows me to call my DeleteShot command, Remove an item from my ObservableCollection, update the "shotNumber" property of each item in my ObservableCollection, and have the DataGrid update to present the "Shot #" column correctly, without needing to DataGrid.Items.Refresh() in the .xaml.cs
.xaml
<MenuItem Header="Delete" Command="{Binding DataContext.DeleteShotCommand, Source={x:Reference dummyElement}}"
.ViewModel
public RelayCommand DeleteShotCommand { get; private set; }
DeleteShotCommand = new RelayCommand(DeleteShot);
public void DeleteShot(object obj)
{
    Shots.RemoveAt(SelectedIdx);
    foreach(nsbRollShot shot in shots)
    {
        shot.ShotNumber = shots.IndexOf(shot) + 1;
    }
    NotifyPropertyChanged("Shots");
}
I think I got that all copy/pasted in there correctly, I'll keep checking back to answer any questions that come up. 
