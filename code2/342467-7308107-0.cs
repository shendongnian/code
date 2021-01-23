    string[] itemInList =  listView1.Items.OfType<ListViewItem>( ).Select( p => p.Text ).ToArray( );
    string[] lineInHosts = File.ReadAllLines( @"C:\Test.txt" ).ToArray<string>( );
    string itemName;
    ListViewItem foundItem;
                    
    foreach ( var item in itemInList )
    {
         if (lineInHosts.Contains(item))
         {
             itemName = item.ToString( );
             foundItem = listView1.FindItemWithText( itemName );
             foundItem.Checked = true;                    
         }
    }
