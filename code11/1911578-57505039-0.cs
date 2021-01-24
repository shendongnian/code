Since your if/else both return, it will never get to the actual update code.  You want something like this:
        public IHttpActionResult PostAddSubjectCode([FromBody] ConfigSubjectCode SubjectCodes)
        {
            string Subject_Code = "";
            string Subject_Name = "";
            if (String.IsNullOrEmpty(Subject_Code) && String.IsNullOrEmpty(Subject_Name))
            {
                return NotFound();
            }
            else
            {
                string sql = "INSERT INTO[dbo].[GEO_SUBJECT_CODES] ([Subject_Code],[Subject_Name_BY_CLASS]) VALUES " +
                             "('" + SubjectCodes.Subject_Code + "', '" + SubjectCodes.Subject_Name + "');";
                using(DBConnection dBConnection = new DBConnection()) // added a 'using'
                {
                    dBConnection.UpdateTable(sql);            
                }
                return Ok();
            }
        }   
