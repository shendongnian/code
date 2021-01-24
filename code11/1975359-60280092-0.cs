c#
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.XSSF.UserModel;
using NPOI.XSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System;
using NPOI.HSSF.Record;
using System.Diagnostics;
/// <summary>
/// Allow to convert between xls and xlsx excel formats
/// </summary>
public class ExcelFormatConverter
{
    private Dictionary<short, ICellStyle> styleDict = new Dictionary<short, ICellStyle>();
    private IWorkbook sWorkbook = null;
    private IWorkbook dWorkbook = null;
    /// <summary>
    /// Convert the source file to the format of the destination file
    /// </summary>
    /// <param name="sFileName">Source file to convert</param>
    /// <param name="dFileName">Destination file where the conversion is saved</param>
    public void ConvertFile(string sFileName, string dFileName)
    {
        styleDict.Clear();
        IWorkbook sWorkbook;
        using (FileStream sFileStream = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
        {
            sWorkbook = WorkbookFactory.Create(sFileStream, ImportOption.All);
        }
        IWorkbook dWorkbook = null;
        string ext = Path.GetExtension(dFileName).ToLower().Replace(".", "");
        if (ext.Equals("xlsx"))
            dWorkbook = new XSSFWorkbook();
        else if (ext.Equals("xls"))
            dWorkbook = new HSSFWorkbook();
        else
            throw new Exception("Not Supported Format");
        this.sWorkbook = sWorkbook;
        this.dWorkbook = dWorkbook;
        if (sWorkbook is HSSFWorkbook)
        {
            try { HSSFOptimiser.OptimiseCellStyles((HSSFWorkbook)sWorkbook); }
            catch { }
        }
        for (short s = 0; s < sWorkbook.NumCellStyles; s++)
        {
            ICellStyle sCellStyle = sWorkbook.GetCellStyleAt(s);
            ICellStyle dCellStyle = dWorkbook.CreateCellStyle();
            //DebugCellStyle(Path.GetDirectoryName(sFileName) + @"\debug", sCellStyle);
            ConvertCellStyle(sCellStyle, dCellStyle);
        }
        if(dWorkbook is HSSFWorkbook)
        {
            try { HSSFOptimiser.OptimiseCellStyles((HSSFWorkbook)dWorkbook); }
            catch { }
        }
        ConvertWorkBook(sWorkbook, dWorkbook);
        using (FileStream dFileStream = new FileStream(dFileName, FileMode.CreateNew, FileAccess.ReadWrite))
        {
            dWorkbook.Write(dFileStream);
        }
        this.dWorkbook = null;
        this.sWorkbook = null;
       
    }
    /// <summary>
    /// Used to debug
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="cellStyle"></param>
    private void DebugCellStyle(string fileName, ICellStyle cellStyle)
    {
        string text = "---------------------------------------------------------------------\r\n";
        text += "Alignment : " + cellStyle.Alignment.ToString() + "\r\n";
        text += "BorderBottom : " + cellStyle.BorderBottom.ToString() + "\r\n";
        text += "BorderDiagonal : " + cellStyle.BorderDiagonal.ToString() + "\r\n";
        text += "BorderDiagonalColor : " + cellStyle.BorderDiagonalColor.ToString() + "\r\n";
        text += "BorderDiagonalLineStyle : " + cellStyle.BorderDiagonalLineStyle.ToString() + "\r\n";
        text += "BorderLeft : " + cellStyle.BorderLeft.ToString() + "\r\n";
        text += "BorderRight : " + cellStyle.BorderRight.ToString() + "\r\n";
        text += "BorderTop : " + cellStyle.BorderTop.ToString() + "\r\n";
        text += "BottomBorderColor : " + cellStyle.BottomBorderColor.ToString() + "\r\n";
        text += "DataFormat : " + cellStyle.DataFormat.ToString() + "\r\n";
        text += "FillBackgroundColor : " + cellStyle.FillBackgroundColor.ToString() + "\r\n";
        text += "FillBackgroundColorColor : " + (cellStyle.FillBackgroundColorColor == null ? "null" : cellStyle.FillBackgroundColorColor.ToString()) + "\r\n";
        text += "FillForegroundColor : " + cellStyle.FillForegroundColor.ToString() + "\r\n";
        text += "FillForegroundColorColor : " + (cellStyle.FillForegroundColorColor == null ? "null" : cellStyle.FillForegroundColorColor.ToString()) + "\r\n";
        text += "FillPattern : " + cellStyle.FillPattern.ToString() + "\r\n";
        text += "FontIndex : " + cellStyle.FontIndex.ToString() + "\r\n";
        text += "Indention : " + cellStyle.Indention.ToString() + "\r\n";
        text += "Index : " + cellStyle.Index.ToString() + "\r\n";
        text += "IsHidden : " + cellStyle.IsHidden.ToString() + "\r\n";
        text += "IsLocked : " + cellStyle.IsLocked.ToString() + "\r\n";
        text += "LeftBorderColor : " + cellStyle.LeftBorderColor.ToString() + "\r\n";
        text += "RightBorderColor : " + cellStyle.RightBorderColor.ToString() + "\r\n";
        text += "Rotation : " + cellStyle.Rotation.ToString() + "\r\n";
        text += "ShrinkToFit : " + (cellStyle is XSSFCellStyle ? "Not implemented" : cellStyle.ShrinkToFit.ToString()) + "\r\n";
        text += "TopBorderColor : " + cellStyle.TopBorderColor.ToString() + "\r\n";
        text += "VerticalAlignment : " + cellStyle.VerticalAlignment.ToString() + "\r\n";
        text += "WrapText : " + cellStyle.WrapText.ToString() + "\r\n";
        File.AppendAllText(fileName, text);
    }
    private void ConvertCellStyle(ICellStyle sCellStyle, ICellStyle dCellStyle)
    {
        try { dCellStyle.Alignment = sCellStyle.Alignment; }
        catch { }
        try { dCellStyle.BorderBottom = sCellStyle.BorderBottom; }
        catch { }
        try { dCellStyle.BorderDiagonal = sCellStyle.BorderDiagonal; }
        catch { }
        try { dCellStyle.BorderDiagonalColor = sCellStyle.BorderDiagonalColor; }
        catch { }
        try { dCellStyle.BorderDiagonalLineStyle = sCellStyle.BorderDiagonalLineStyle; }
        catch { }
        try { dCellStyle.BorderLeft = sCellStyle.BorderLeft; }
        catch { }
        try { dCellStyle.BorderRight = sCellStyle.BorderRight; }
        catch { }
        try { dCellStyle.BorderTop = sCellStyle.BorderTop; }
        catch { }
        try { dCellStyle.BottomBorderColor = sCellStyle.BottomBorderColor; }
        catch { }
        try { dCellStyle.DataFormat = ConvertFormat(sCellStyle.DataFormat); }
        catch { }
        try { dCellStyle.FillBackgroundColor = sCellStyle.FillBackgroundColor; }
        catch { }
        try { dCellStyle.FillForegroundColor = sCellStyle.FillForegroundColor; }
        catch { }
        try { dCellStyle.FillPattern = sCellStyle.FillPattern; }
        catch { }
        try { dCellStyle.SetFont(ConvertFont(sCellStyle.GetFont(this.sWorkbook))); }
        catch { }
        try { dCellStyle.Indention = sCellStyle.Indention; }
        catch { }
        try { dCellStyle.IsHidden = sCellStyle.IsHidden; }
        catch { }
        try { dCellStyle.IsLocked = sCellStyle.IsLocked; }
        catch { }
        try { dCellStyle.LeftBorderColor = sCellStyle.LeftBorderColor; }
        catch { }
        try { dCellStyle.RightBorderColor = sCellStyle.RightBorderColor; }
        catch { }
        try { dCellStyle.Rotation = sCellStyle.Rotation; }
        catch { }
        try { dCellStyle.TopBorderColor = sCellStyle.TopBorderColor; }
        catch { }
        try { dCellStyle.VerticalAlignment = sCellStyle.VerticalAlignment; }
        catch { }
        try { dCellStyle.WrapText = sCellStyle.WrapText; }
        catch { }
    }
    private short ConvertFormat(short index)
    {
        IDataFormat sFormat = this.sWorkbook.CreateDataFormat();
        IDataFormat dFormat = this.dWorkbook.CreateDataFormat();
        return dFormat.GetFormat(sFormat.GetFormat(index));
    }
    private IFont ConvertFont(IFont sFont)
    {
        IFont dFont = this.dWorkbook.CreateFont();
        try { dFont.Boldweight = sFont.Boldweight; }
        catch { }
        try { dFont.Charset = sFont.Charset; }
        catch { }
        try { dFont.FontName = sFont.FontName; }
        catch { }
        try { dFont.FontHeightInPoints = sFont.FontHeightInPoints; }
        catch { }
        try { dFont.IsItalic = sFont.IsItalic; }
        catch { }
        try { dFont.IsStrikeout = sFont.IsStrikeout; }
        catch { }
        try { dFont.TypeOffset = sFont.TypeOffset; }
        catch { }
        try
        {
            byte[] rgb = null;
            if (sWorkbook is HSSFWorkbook)
            {
                if (((HSSFWorkbook)sWorkbook).GetCustomPalette().GetColor(sFont.Color) == null)
                {
                    rgb = new byte[] { (byte)255, (byte)255, (byte)255 };
                }
                else
                {
                    rgb = ((HSSFWorkbook)sWorkbook).GetCustomPalette().GetColor(sFont.Color).RGB;
                    if (dWorkbook is XSSFWorkbook)
                    {
                        if (rgb[0] == 0 && rgb[1] == 0 && rgb[2] == 0)
                            rgb = new byte[] { (byte)255, (byte)255, (byte)255 };
                        else if (rgb[0] == 255 && rgb[1] == 255 && rgb[2] == 255)
                            rgb = new byte[] { (byte)0, (byte)0, (byte)0 };
                    }
                }
            }
            else if (sWorkbook is XSSFWorkbook)
            {
                if (sFont == null)
                    rgb = new byte[] { (byte)255, (byte)255, (byte)255 };
                else
                {
                    XSSFColor xColor = ((XSSFFont)sFont).GetXSSFColor();
                    if (xColor == null)
                        rgb = new byte[] { (byte)255, (byte)255, (byte)255 };
                    else
                        rgb = xColor.GetRgb();
                }
            }
            if (dWorkbook is HSSFWorkbook)
            {
                // Bug NPOI couleurs noir et blanc sont inversée
                if (sWorkbook is XSSFWorkbook)
                {
                    if (rgb[0] == 0 && rgb[1] == 0 && rgb[2] == 0)
                        rgb = new byte[] { (byte)255, (byte)255, (byte)255 };
                    else if (rgb[0] == 255 && rgb[1] == 255 && rgb[2] == 255)
                        rgb = new byte[] { (byte)0, (byte)0, (byte)0 };
                }
                dFont.Underline = sFont.Underline;
                HSSFColor color = ((HSSFWorkbook)dWorkbook).GetCustomPalette().FindColor(rgb[0], rgb[1], rgb[2]);
                if (color == null)
                    color = ((HSSFWorkbook)sWorkbook).GetCustomPalette().AddColor(rgb[0], rgb[1], rgb[2]);
                dFont.Color = color.Indexed;
            }
            else if (dWorkbook is XSSFWorkbook)
            {
                // Underline conditionel à caus e d'un bug dans NPOI
                if (sFont.Underline != FontUnderlineType.None)
                    ((XSSFFont)dFont).Underline = sFont.Underline;
                ((XSSFFont)dFont).SetColor(new XSSFColor(rgb));
            }
        }
        catch { }
        return dFont;
    }
    /// <summary>
    Convert the source work book to the format of the destination workbook
    /// Convertit le workbook source dans le format du workbook destination
    /// </summary>
    /// <param name="sWorkbook">workbook source</param>
    /// <param name="dWorkbook">workbook destination</param>
    public void ConvertWorkBook(IWorkbook sWorkbook, IWorkbook dWorkbook)
    {
        try { dWorkbook.MissingCellPolicy = sWorkbook.MissingCellPolicy; }
        catch { }
        for (int i = 0; i < sWorkbook.NumberOfSheets; i++)
        {
            ISheet sSheet = sWorkbook.GetSheetAt(i);
            ISheet dSheet = dWorkbook.CreateSheet(sSheet.SheetName);
            try { dSheet.ForceFormulaRecalculation = sSheet.ForceFormulaRecalculation; }
            catch { }
            ConvertSheet(sSheet, dSheet);
            SheetState state = SheetState.Visible;
            try
            {
                if (sWorkbook.IsSheetHidden(i))
                    state = SheetState.Hidden;
                if (sWorkbook.IsSheetVeryHidden(i))
                    state = SheetState.VeryHidden;
                dWorkbook.SetSheetHidden(i, state);
            }
            catch { }
        }
        try { dWorkbook.SetActiveSheet(sWorkbook.ActiveSheetIndex); }
        catch { }
    }
    protected void ConvertSheet(ISheet sSheet, ISheet dSheet)
    {
        int numberOfColumns = 0;
        for(int i = sSheet.FirstRowNum; i <= sSheet.LastRowNum; i++)
        {
            try { ConvertRow(sSheet.GetRow(i), dSheet.CreateRow(i)); }
            catch { }
            try
            {
                if (sSheet.GetRow(i) != null && numberOfColumns < sSheet.GetRow(i).LastCellNum)
                    numberOfColumns = sSheet.GetRow(i).LastCellNum;
            }
            catch { }
        }
        for(int i = 1; i <= numberOfColumns;i++)
        {
            try { dSheet.SetColumnWidth(i, sSheet.GetColumnWidth(i)); }
            catch { }
            try
            {
                if (sSheet.IsColumnHidden(i))
                    dSheet.SetColumnHidden(i, true);
            }
            catch { }
        }
        for (int i = 0; i < sSheet.NumMergedRegions; i++)
        {
            try { dSheet.AddMergedRegion(sSheet.GetMergedRegion(i)); }
            catch { }
        }
        try { dSheet.DisplayFormulas = sSheet.DisplayFormulas; }
        catch { }
        try { dSheet.DisplayGridlines = sSheet.DisplayGridlines; }
        catch { }
        try { dSheet.DisplayGuts = sSheet.DisplayGuts; }
        catch { }
        try { dSheet.DisplayRowColHeadings = sSheet.DisplayRowColHeadings; }
        catch { }
        try { dSheet.DisplayZeros = sSheet.DisplayZeros; }
        catch { }
        try { dSheet.FitToPage = sSheet.FitToPage; }
        catch { }
        try { dSheet.HorizontallyCenter = sSheet.HorizontallyCenter; }
        catch { }
        try { dSheet.SetMargin(MarginType.BottomMargin, sSheet.GetMargin(MarginType.BottomMargin)); }
        catch { }
        try { dSheet.SetMargin(MarginType.FooterMargin, sSheet.GetMargin(MarginType.FooterMargin)); }
        catch { }
        try { dSheet.SetMargin(MarginType.HeaderMargin, sSheet.GetMargin(MarginType.HeaderMargin)); }
        catch { }
        try { dSheet.SetMargin(MarginType.LeftMargin, sSheet.GetMargin(MarginType.LeftMargin)); }
        catch { }
        try { dSheet.SetMargin(MarginType.RightMargin, sSheet.GetMargin(MarginType.RightMargin)); }
        catch { }
        try { dSheet.SetMargin(MarginType.TopMargin, sSheet.GetMargin(MarginType.TopMargin)); }
        catch { }
    }
    protected void ConvertRow(IRow sRow, IRow dRow)
    {
        if (sRow != null && dRow != null)
        {
            try
            {
                if (sRow.RowStyle != null)
                    dRow.RowStyle = styleDict[sRow.RowStyle.Index];
            }
            catch { }
            if (sRow.FirstCellNum >= 0)
            {
                for (int i = sRow.FirstCellNum; i <= sRow.LastCellNum; i++)
                {
                    if (sRow.GetCell(i) != null)
                    {
                        try { ConvertCell(sRow.GetCell(i), dRow.CreateCell(i)); }
                        catch { }
                        try { dRow.Height = sRow.Height; }
                        catch { }
                    }
                }
            }
        }
    }
    protected void ConvertCell(ICell sCell, ICell dCell)
    {
        if (sCell != null && dCell != null)
        {
            try { dCell.CellComment = sCell.CellComment; }
            catch { }
            try
            {
                if (sCell.CellStyle != null)
                    dCell.CellStyle = styleDict[sCell.CellStyle.Index];
            }
            catch { }
            switch (sCell.CellType)
            {
                case CellType.String:
                    try { dCell.SetCellValue(sCell.StringCellValue); }
                    catch { }
                    break;
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(sCell))
                    {
                        try { dCell.SetCellValue(sCell.DateCellValue); }
                        catch { }
                        //short format = dWorkbook.CreateDataFormat().GetFormat("MM-dd-yy HH:mm:ss.fff");
                        try { dCell.CellStyle.CloneStyleFrom(sCell.CellStyle); }
                        catch { }
                    }
                    else
                    {
                        try { dCell.SetCellValue(sCell.NumericCellValue); }
                        catch { }
                    }
                    break;
                case CellType.Boolean:
                    try { dCell.SetCellValue(sCell.BooleanCellValue); }
                    catch { }
                    break;
                case CellType.Error:
                    try { dCell.SetCellErrorValue(sCell.ErrorCellValue); }
                    catch { }
                    break;
                case CellType.Formula:
                    try { dCell.SetCellFormula(sCell.CellFormula); }
                    catch { }
                    break;
                default:
                    try { dCell.SetCellType(CellType.Blank); }
                    catch { }
                    break; 
            }
        }
    }        
}
The conversion can take time depending of the size of the excel file.
And it doesn't work for excel files with charts or macros.
But it's handy for styled datasheets. I made it based on [NPOI version 2.3.0](https://www.nuget.org/packages/NPOI/2.3.0)
I don't know if it works with newer version.
Feel free to use it or modify it.
