    private void listViewCards_KeyDown(object sender, KeyEventArgs e)
    {
         IList selectedListViewItems = listViewCards.SelectedItems;
         if (selectedListViewItems.Count > 1)
         {
             //delete all selected items from xml:
             var collection = selectedListViewItems.Cast<XmlNode>();  //assuming your underlying data is XmlNode
             foreach(XmlNode node in collection)
             {
                 //do whatever you want to do with node
                 if (node.InnerText.Equals( ??? ))
                 {
                     //mark for deleting
                 }
             }
         }
    }
