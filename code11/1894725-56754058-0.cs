            string tableData = "Test;One;3;End\nNew line;Two;4;End";
            string bkmName = "TableTarget";
            if (doc.Bookmarks.Exists(bkmName))
            {
                Word.Range rngTable = doc.Bookmarks[bkmName].Range;
                rngTable.Text = tableData;
                Word.Table tbl = rngTable.ConvertToTable(";", missing, missing, missing, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing,
                    missing, Word.WdDefaultTableBehavior.wdWord8TableBehavior);
            }
