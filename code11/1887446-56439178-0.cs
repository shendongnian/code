    foreach (ListViewItem item in lvwAttributes.Items)
        {
            if (lvwAttributes.Items.Count > 0)
            {
                table.AddCell(new Phrase(item.SubItems[0].Text.ToString(), font5));
                table.AddCell(new Phrase(item.SubItems[1].Text.ToString(), font5));
                table.AddCell(new Phrase(item.SubItems[2].Text.ToString(), font5));
                table.AddCell(new Phrase(item.SubItems[3].Text.ToString(), font5));
                table.AddCell(new Phrase(item.SubItems[4].Text.ToString(), font5));
                table.AddCell(new Phrase(item.SubItems[5].Text.ToString(), font5));
            }
        }
