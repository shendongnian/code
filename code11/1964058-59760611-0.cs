          public class CellProperties { 
            public Boolean Correct { get; } 
            public Boolean Changed { get; } 
            public CellProperties(Boolean correct, Boolean changed) 
            { 
                Correct = correct; Changed = changed; 
            } 
        } 
    CellProperties props = this.dataCOMPGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag 
                               as CellProperties;
    if(props.Correct)
    ...
  
