 <Button Content="Usun" Command="{Binding UsunCommand}"  CommandParameter="{Binding Path=SelectedItem, ElementName=dataGrid}"/>
  <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding List}" Name="dataGrid"
.....
In **ViewModel** i change object type to type in DataGrid
 public ICommand UsunCommand { get { return new RelayCommand<ObiektyForAllViews>(OnEdit); } }
        private void OnEdit(ObiektyForAllViews itemToEdit)
        {
            
                int idObiektu = itemToEdit.idObiektu;
                atmaEntites.Database.ExecuteSqlCommand("UPDATE Obiekty SET stan = '2' WHERE idObiektu = " + idObiektu + ";");
            
        }
