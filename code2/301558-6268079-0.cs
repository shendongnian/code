     var matchingItem = listBox1.Items.Cast<[YourItemDataType]>().ToList()
                    .Where(x => x.Desc.Contains(searchString))
                    .ToList();
                for (var i = 0; i < matchingItem.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                }
