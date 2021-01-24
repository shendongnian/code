            try
            {
                using (sqlConnection)
                {
                    DateTime startDate = Convert.ToDateTime(firstDate);
                    DateTime endDate = Convert.ToDateTime(secondDate);
                    var summary_statement = sqlConnection.Query
                        ("get_summary_memberStatement", new {
                            member_number,
                            startDate,
                            endDate
                        }, commandType: CommandType.StoredProcedure);
                    return Json(summary_statement, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
