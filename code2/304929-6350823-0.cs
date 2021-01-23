var list = new Dictionary&lt;string, List&lt;string>>
                           {
                               {"Name1", new List<string> {"item1", "item2", "item3"}},
                               {"Name2", new List<string> {"item1", "item2", "item3"}},
                               {"Name3", new List<string> {"item1", "item2", "item3"}},
                               {"Name4", new List<string> {"item1", "item2", "item3"}},
                               {"Name5", new List<string> {"item1", "item2", "item3"}}
                           };
            foreach (var category in list)
            {
                var checkBoxList = new CheckBoxList
                                       {
                                           Text = category.Key
                                       };
                
                foreach (var value in category.Value)
                {
                    var listItem = new ListItem(value);
                    checkBoxList.Items.Add(listItem);
                }
            }
