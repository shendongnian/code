    foreach (AppTable table in appTableList)
            {
                if (!cbxUpdateAppType.Items.Contains(table.Type))
                    cbxUpdateAppType.Items.Add(table.Type);
            }
