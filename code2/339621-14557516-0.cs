    using LinqToExcel;
    filename = FileUpload1.FileName;
    FileUpload1.SaveAs(Server.MapPath("~/Excelfiles/"+filename));
    var xl = new ExcelQueryFactory(Server.MapPath("~/Excelfiles/" + filename));
    var worksheetNames = xl.GetWorksheetNames();           
    DropDownList2.DataSource = worksheetNames;
    DropDownList2.DataBind();
