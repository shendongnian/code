                foreach (listItem item in descriptionclb.Items)
                {
                    ItemTable.Rows[i].Cells[j].Paragraphs[0].Append(item.ProdName);
                    j++;
                    ItemTable.Rows[i].Cells[j].Paragraphs[0].Append(item.ProdName);
                    j++;
                    ItemTable.Rows[i].Cells[j].Paragraphs[0].Append(item.Quantity.ToString());
                    j++;
                    ItemTable.Rows[i].Cells[j].Paragraphs[0].Append(item.Price.ToString());
                    j++;
                    ItemTable.Rows[i].Cells[j].Paragraphs[0].Append(Total.ToString());
                    i++;
                    j = 0;
                }
