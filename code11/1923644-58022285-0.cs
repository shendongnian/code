    public class LastNColumnsPivotTable : IPivotTable {
      IPivotTable basePvtTbl;
    
      public LastNColumnsPivotTable(IPivotTable pvtTbl, int lastN) {
        basePvtTbl = pvtTbl;
        if (basePvtTbl.ColumnKeys.Length>lastN) {
          lastColumnKeys = basePvtTbl.ColumnKeys.Skip(basePvtTbl.ColumnKeys.Length - lastN).ToArray();
        } else {
          lastColumnKeys = basePvtTbl.ColumnKeys;
        }
      }
    
      public string[] Columns { get { return basePvtTbl.Columns; } }
      public string[] Rows { get { return basePvtTbl.Rows; } }
    
      ValueKey[] lastColumnKeys;
      public ValueKey[] ColumnKeys { get { return lastColumnKeys; } }
    
      public ValueKey[] RowKeys { get { return basePvtTbl.RowKeys; } }
      public IPivotData PivotData { get { return basePvtTbl.PivotData; } }
    
      public IAggregator GetValue(ValueKey rowKey, ValueKey colKey) {
        return basePvtTbl.GetValue(rowKey, colKey);
      }
    }
