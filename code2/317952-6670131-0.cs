     // Send the request to search the Inbox and get the results.
            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, FinalsearchFilter, view);
            
            // Process each item.
            if (findResults.Items.Count > 0)
            {
                foreach (Item myItem in findResults.Items)
                {
                    if (myItem is EmailMessage)
                    {
                        Console.WriteLine((myItem as EmailMessage).Subject);
                    }
                    if (myItem.ExtendedProperties.Count > 0)
                    {
                        // Display the extended property's name and property.
                        foreach (ExtendedProperty extendedProperty in myItem.ExtendedProperties)
                        {
                            Console.WriteLine(" Extended Property Name: " + extendedProperty.PropertyDefinition.Name);
                            Console.WriteLine(" Extended Property Value: " + extendedProperty.Value);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No Items Found!");
            }
        }
