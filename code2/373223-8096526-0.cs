                //Create root folder
                SPListItem rootItem = navigation.Items.Add();
                SPContentType contentType = navigation.ContentTypes["ListLevel"];
                rootItem["ContentTypeId"] = contentType.Id;
                rootItem["Title"] = "root";
                rootItem.Update();
                navigation.Update();
                qry2.Query = "";
                SPListItemCollection navItems = navigation.GetItems(qry2);
                foreach (SPListItem item in navItems)
                {
                    if (item.Title == "root")
                    {
                        item["Name"] = "root";
                        item.Update();
                    }
                }
