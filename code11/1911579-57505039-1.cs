Since your if/else both return, it will never get to the actual update code.  And you were assigned both variable to a fixed empty string, which would never cause the if/else to work in any case.  You want something like this:
        public IHttpActionResult PostAddSubjectCode([FromBody] ConfigSubjectCode SubjectCodes)
        {
            string Subject_Code = SubjectCodes.Subject_Code; // these can't be fixed ""
            string Subject_Name = SubjectCodes.Subject_Name; // these can't be fixed ""
            if (String.IsNullOrEmpty(Subject_Code) && String.IsNullOrEmpty(Subject_Name))
            {
                return NotFound();
            }
            else
            {
                string sql = "INSERT INTO[dbo].[GEO_SUBJECT_CODES] ([Subject_Code],[Subject_Name_BY_CLASS]) VALUES " +
                             "('" + Subject_Code + "', '" + Subject_Name + "');";
                DBConnection dBConnection = new DBConnection();
                dBConnection.UpdateTable(sql);            
                return Ok();
            }
        }   
