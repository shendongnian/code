    //create treeNode myParent = null;  
    while (Reader.Read()) 
    { 
        switch (reader.NodeType) 
        { 
            case XmlNodeType.Element: // The node is an element. 
                var newNode = new TreeViewItem 
                { 
                    Header = reader.Name 
                }; 
 
                if(theParent !=null) 
                { 
                    theParent.Items.Add(newnode);  
                } 
                else 
                { 
                    treeView.Items.Add(newnode);  
                } 
                theParent = newnode; 
                break; 
            case XmlNodeType.Text: //Display the text in each element. 
                Console.WriteLine(reader.Value); 
                break; 
            case XmlNodeType.EndElement: //Display the end of the element. 
                Console.Write("</" + reader.Name); 
                Console.WriteLine(">"); 
                if (theParent != null)
                {
                    theParent = theParent.Parent;
                } 
                break; 
         } 
     } 
