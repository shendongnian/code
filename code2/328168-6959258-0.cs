    private static void updateFields()
            {
                //Loads the site list
                clientContext.Load(list);
                //Creates a ListItemCollection object from list
                ListItemCollection listItems = list.GetItems(CamlQuery.CreateAllItemsQuery());
                //Loads the listItems
                clientContext.Load(listItems);
                //Executes the previous queries on the server
                clientContext.ExecuteQuery();
    
                //For each listItem...
                foreach (var listItem in listItems)
                {
                    //Writes out the item ID and Title
                    Console.WriteLine("Id: {0} Title: {1}", listItem.Id, listItem["Title"]);
                    //Loads the files from the listItem
                    clientContext.Load(listItem.File);
                    //Executes the previous query
                    clientContext.ExecuteQuery();
                    //Writes out the listItem File Name
                    Console.WriteLine("listItem File Name: {0}", listItem.File.Name);
    
                    //Looks for the most recently uploaded file, if found...
                    if (listItem.File.Name.Contains("Sunset"))
                    {
                        //Changes the Title field value
                        listItem["Title"] = title;
                        //Changes the Keywords field value
                        listItem["Keywords"] = keywords1 + keywords2 + keywords3;
                        //Writes out the item ID, Title, and Keywords
                        Console.WriteLine("Id: {0} Title: {1} Keywords: {2}", listItem.Id, listItem["Title"], listItem["Keywords"]);
                    }
                    //Remember changes...
                    listItem.Update();
                }
                //Executes the previous query and ensures changes are committed to the server
                clientContext.ExecuteQuery();
            }
