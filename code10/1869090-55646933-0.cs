      <DataGrid Name="item_list">
            <DataGrid.Columns>
                    <DataGridTextColumn x:Name="item_name" Binding="{Binding itemname}"  Width="*" Header="Item Name" />
                    <DataGridTextColumn x:Name="item_unit" Binding="{Binding itemitemunit}"  Width="*" Header="Unit"/>
                    <DataGridTextColumn x:Name="item_qty" Binding="{Binding itemqty}"  Width="*" Header="Qnty"/>
                    <DataGridTextColumn x:Name="item_rate" Binding="{Binding itemrate}"   Width="*" Header="Unit Rate"/>
                <DataGridTextColumn x:Name="total_rate"   Width="*" Header="Total Rate"/>
                <DataGridTextColumn x:Name="item_cgst"   Width="*"  Header="CGST(%)"/>
                <DataGridTextColumn x:Name="item_sgst"   Width="*" Header="SGST(%)"/>
                <DataGridTextColumn x:Name="total_amount"   Width="*" Header="Total Amount"/>
            </DataGrid.Columns>
            </DataGrid>
      private void add_sale_Loaded()
            {
               
                collection.Add(new Proxy { itemitemunit = "1", itemname = "1", itemqty = "1", itemrate = "1" });
                item_list.CanUserAddRows = false;
                item_list.AutoGenerateColumns = false;
                item_list.ItemsSource = collection;
            }
    //Global
     ObservableCollection<Proxy> collection { get; set; }
    //CTOR
     collection = new ObservableCollection<Proxy>();
                item_list.ItemsSource = collection;
                add_sale_Loaded();
                add_sale_Loaded(); 
