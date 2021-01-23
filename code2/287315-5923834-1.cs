    using OExcel = Microsoft.Office.Interop.Excel;
    //...
    OExcel.Application app = new OExcel.ApplicationClass(); 
    OExcel.Workbook wb = app.Workbooks.Open(filepath, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    wb.XmlMaps["MAPNAME"].ImportXml(string_with_xml);
