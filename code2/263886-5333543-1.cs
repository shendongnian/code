    Application excelapp = new Application();
    excelapp.Visible = true;
    _Workbook workbook = (_Workbook)(excelapp.Workbooks.Add(Type.Missing));
    _Worksheet worksheet = (_Worksheet)workbook.ActiveSheet;
    worksheet.Cells[1, 1] = "First Name";
    worksheet.Cells[1, 2] = "Last Name";
    worksheet.Cells[1, 3] = "Email";
    worksheet.Cells[1, 4] = "Phone Number";
    int row = 1;
    foreach (var contact in contacts)
    {
        row++;
        worksheet.Cells[row, 1] = contact.Firstname;
        worksheet.Cells[row, 2] = contact.Lastname;
        worksheet.Cells[row, 3] = contact.Email;
        worksheet.Cells[row, 4] = contact.PhoneNumber;
    }
    excelapp.UserControl = true;
