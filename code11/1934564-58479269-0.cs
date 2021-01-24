    string result = CombineCheckboxLists(checkBoxList1, checkBoxList2, checkboxlist3);
     private string CombineCheckboxLists(params CheckBoxList[] list)
        {
            StringBuilder builder = new StringBuilder();
            string result = string.Empty;
            if (list?.Length > 0)
            {
                int minItemsCount = list.Min(l => l.Items.Count);
                if (minItemsCount > 0)
                {
                    for (int i = 0; i < minItemsCount; i++)
                    {
                        builder.Append(string.Join(",", list
                            .Where(l => l.Items[i].Selected)
                            .Select(l=> l.Items[i].Text)));
                        //if you want to merge all iteration via ",", please use following lines instead of above -- [marked as **] 
                        // ** //builder.Append($"{string.Join(",", list.Select(l => l.Items[i].Value))},");
                    }
                }
            }
            result = builder.ToString();
            // ** // result = result.TrimEnd(',');
            return result;
        }
