    string strPassword = oldpassword;
    Excel.Worksheet wsheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[Name];
    try { 
      // try the old password first (throws a COM exception if it fails)
      wsheet.Unprotect(oldpassword);
    } catch {
      // ideally we should make sure we're only handling an invalid password error here
      try {
        // couldn't unprotect with the old password - try the new password
        strPassword = newpassword;
        wsheet.Unprotect(strPassword);
      } catch(Exception ex) {
        // TODO neither password worked - what do we do now? [insert code here...]
      }
    }
