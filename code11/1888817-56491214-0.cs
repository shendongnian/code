    public void UngroupFromAll(){
     IXLWorksheet ws = new XLWorkbook().AddWorksheet("Sheet1");
     ws.Rows(1, 2).Group();
     ws.Rows(1, 2).Ungroup(true);
     }
