    <Window.Resources>
        <CollectionViewSource x:Key="ItemCollectionViewSource"  CollectionViewType="ListCollectionView"/>
    </Window.Resources> 
    <DataGrid
      DataContext="{StaticResource ItemCollectionViewSource}"
      ItemsSource="{Binding}"
      AutoGenerateColumns="False"
      CanUserAddRows="False">  
    //create business data
    var itemList = new List<stockitem>();
    itemList.Add(new StockItem {Name= "Many items",      Quantity=100, IsObsolete=false});
    itemList.Add(new StockItem {Name= "Enough items",    Quantity=10,  IsObsolete=false});
    ...
     
    //link business data to CollectionViewSource
    CollectionViewSource itemCollectionViewSource;
    itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
    itemCollectionViewSource.Source = itemList; 
