foreach (Microsoft.Office.Interop.Word.Table table in objDoc.Tables)
{             
    for (int row = 1; row <= table.Rows.Count; row++)
    {
        for (int col = 1; col <= table.Columns.Count; col++)
        {
            // Convert the formatted list number to plain text, then undo the conversion                   
            table.Cell(row, col).Range.ListFormat.ConvertNumbersToText();
            string cellContent = table.Cell(row, col).Range.Text;
            objDoc.Undo(1);
            // remove end-of-cell characters
            cellContent = trimCellText2(cellContent);
            // Replace remaining paragraph marks with the excel newline character     
            char[] linefeeds = new char[] { '\r', '\n' };
            string[] temp1 = cellContent.Split(linefeeds, StringSplitOptions.RemoveEmptyEntries);
            cellContent = String.Join("\n", temp1);
            // Replace tabs from the list format conversion with spaces
            char[] tabs = new char[] { '\t', ' ' };
            string[] temp2 = cellContent.Split(tabs, StringSplitOptions.RemoveEmptyEntries);
            cellContent = String.Join(" ", temp2);
            worksheet.Cells[row, col] = cellContent;
        }
    }
}
private static string trimCellText2(string myString)
{
    int len = myString.Length;
    string charString13 = "" + (char)13;
    string charString7 = "" + (char)7;
    while ((len > 0 && myString.Substring(len - 1) == charString13) || (myString.Substring(len - 1) == charString7))
        myString = myString.Substring(0, Math.Min(len - 1, len));
    return myString;
}
And here is the resulting output in Excel: [Excel Output][2]
  [1]: https://stackoverflow.com/questions/7265315/replace-multiple-characters-in-a-c-sharp-string
  [2]: https://i.stack.imgur.com/6bQEa.png
