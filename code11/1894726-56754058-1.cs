            string tableData = "Test;One;3;End\nNew line;Two;4;End";
            //Target table, to be extended
            Word.Table tbl = doc.Tables[1];
            Word.Range rngTbl = tbl.Range;
            rngTbl.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            //Target for inserting the data (end of the document)
            Word.Range rng = doc.Content;
            rng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            rng.Text = tableData;
            Word.Table tblExtend = rng.ConvertToTable(";", missing, missing, missing, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing,
                    missing, Word.WdDefaultTableBehavior.wdWord8TableBehavior);
            //Move the new table content to the end of the target table
            tblExtend.Range.Cut();
            rngTbl.PasteAppendTable();
