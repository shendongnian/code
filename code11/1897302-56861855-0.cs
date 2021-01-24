    DataTable subjectCodeList = dBConnection.GetSqlDataTable(sql);
    var subjectCodeToDelete = subjectCodeList.Rows.Find(Subject_Code_ID);
    if (subjectCodeToDelete == null)
        {
            return NotFound();
        }
    dBConnection.SubjectCodes.Remove(subjectCodeToDelete);
    dBConnection.SaveChanges();
