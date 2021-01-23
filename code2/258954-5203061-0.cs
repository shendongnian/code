    using System.Linq;
    
    // ... //
    
    var columnsArray = dtObj.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
