        oTable.Cell(0, 0).Select(); //select the cell
    //set up the left, right and top borders invisible (may be you don't need to do that)
                oTable.Range.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
                oTable.Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleNone;
                oTable.Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
    
    //set up the bottom border blue
                oTable.Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                oTable.Range.Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth050pt;
                oTable.Range.Borders[WdBorderType.wdBorderBottom].Color = WdColor.wdColorBlue;
