    public class ExcelWalker {
        Microsoft.Office.Interop.Excel.Range navigator
        Microsoft.Office.Interop.Excel.Range currentCells
        Integer currentRow,currentColumn
        
        public void GoUpOneRowButKeepColumn(){
           currentCells = navigator.Cells(currentRow++,currentColumn);
        }
    }
