    public class XceedTableAdapter
    {
       private readonly SortedDictionary<string, (int row, int column)> dict;
       
       public XceedTableAdapter(Xceed.Words.NET.Table table)
       {
          this.dict = new SortedDictionary<string, (int, int)>();
          // Copy the content of the table into the dict.
          // If you have duplicate words you need a SortedDictionary<string, List<(int, int)>> type. This is not clear in your question.
          for (var i = 0, i < rowCount; i++)
          {
              for (var j = 0; j < columnCount; j++)
              {
                  // this will overwrite the index if the text was previously found: 
                  this.dict[table.Rows[i].Cells[j].Paragraphs[0].Text] = (i, j);
              }
          }
       }
       public (int, int) GetColumnIndex(string searchText)
       {
          if(this.dict.TryGetValue(searchText, out var index))
          {
              return index;
          }
   
          return (-1, -1);
       }
    }
