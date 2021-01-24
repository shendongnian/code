      private void ActiveWorkbook_BeforeClose(ref bool Cancel)
        {
            DefaultSaveExcel(Excel.ActiveWorkbook,ref Cancel);
            if (!Cancel)
            {
                //if enters here is because the workbook is actually closing
                Delete(Excel.ActiveWorkbook.Name);
            }                     
        }
