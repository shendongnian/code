    <Window.Resources>
            <ObjectDataProvider x:Key="MercerCatalog" ObjectType="{x:Type local:MercerCatalogDataProvider}" MethodName="GetMercerCatalog" />  
        </Window.Resources>
         <Grid>
            <DataGrid Grid.Row="0" CanUserAddRows="False" ItemsSource="{Binding Source={StaticResource MercerCatalog}}"  >    
          </DataGrid>
        </Grid>
 
     public class MercerCatalogDataProvider
        {
            public ObservableCollection<User> ListItems { get; set; }
            public MercerCatalogDataProvider()
            {
                ListItems = new ObservableCollection<User>
                {
    
                  new User { Name = "Item1"},
                  new User { Name = "Item2"},
                  new User { Name = "Item3"},
                  new User { Name = "Item4"}
                };
            }
    
            public ObservableCollection<User> GetMercerCatalog()
            {
                return ListItems;
            }
        }
        public class User
        {
            public bool Add { get; set; } = false;  
            public string Name { get; set; }
            
        }
