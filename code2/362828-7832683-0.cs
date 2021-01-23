    class MyControl : UserControl
    {
       XDocument productTableDocument;
    
       private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
       {
          if (productTableDocument == null)   
          {
             productTableDocument = XDocument.Load("ProductTable.xml");
          }
          // continue working with not null productTableDocument
       }
    }
