        public void CreateNewLeaveRequestDate(DayRequested dayRequested)
        {
            /*
                INSERT INTO MPRLRREQDP 
                (REQUEST_ID, DATE_OF_LEAVE, TIME_OF_LEAVE, HOURS_REQUESTED, REQUEST_TYPE, RELATIONSHIP, NATURE_OF_ILLNESS, 
                    ADDED_TO_TIMESHEET, EMPLOYEE_ID, TIMESHEET_CODE)
                VALUES(NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)                                   
             */
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO MPRLRREQDP ");
            sb.Append("(REQUEST_ID, DATE_OF_LEAVE, TIME_OF_LEAVE, HOURS_REQUESTED, REQUEST_TYPE, RELATIONSHIP, NATURE_OF_ILLNESS, ");
            sb.Append("ADDED_TO_TIMESHEET, EMPLOYEE_ID, TIMESHEET_CODE) ");
            sb.Append("VALUES(@REQUEST_ID, @DATE_OF_LEAVE, @TIME_OF_LEAVE, @HOURS_REQUESTED, @REQUEST_TYPE, @RELATIONSHIP, @NATURE_OF_ILLNESS, ");
            sb.Append("@ADDED_TO_TIMESHEET, @EMPLOYEE_ID, @TIMESHEET_CODE)");
            using (iDB2Connection conn = new iDB2Connection(ConfigurationManager.ConnectionStrings["IbmIConnectionString"].ConnectionString))
            {
                using (iDB2Command cmd = new iDB2Command(sb.ToString(), conn))
                {
                    cmd.Parameters.Add("@REQUEST_ID", iDB2DbType.iDB2Decimal).Value = dayRequested.RequestId;
                    cmd.Parameters.Add("@DATE_OF_LEAVE", iDB2DbType.iDB2Date).Value = Convert.ToDateTime(dayRequested.DateOfLeave).Date;
                    cmd.Parameters.Add("@TIME_OF_LEAVE", iDB2DbType.iDB2Time).Value = Convert.ToDateTime(dayRequested.TimeOfLeave).ToString("HH.mm.ss");
                    cmd.Parameters.Add("@HOURS_REQUESTED", iDB2DbType.iDB2Decimal).Value = dayRequested.HoursRequested;
                    cmd.Parameters.Add("@REQUEST_TYPE", iDB2DbType.iDB2Decimal).Value = dayRequested.RequestType;
                    cmd.Parameters.Add("@RELATIONSHIP", iDB2DbType.iDB2Char).Value = dayRequested.Relationship;
                    cmd.Parameters.Add("@NATURE_OF_ILLNESS", iDB2DbType.iDB2Char).Value = dayRequested.NatureOfIllness;
                    cmd.Parameters.Add("@ADDED_TO_TIMESHEET", iDB2DbType.iDB2Decimal).Value = false;
                    cmd.Parameters.Add("@EMPLOYEE_ID", iDB2DbType.iDB2Decimal).Value = dayRequested.EmployeeId;
                    cmd.Parameters.Add("@TIMESHEET_CODE", iDB2DbType.iDB2Char).Value = dayRequested.TimesheetCode;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
