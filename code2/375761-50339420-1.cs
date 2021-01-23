        [HttpPost]
        [AuthorizeExtended(Roles = "User, Admin")]
        [Route("api/BillingToDo/GenerateInvoices")]
        public async Task<IHttpActionResult> GenerateInvoices(BillingToDoGenerateInvoice model)
        {
            try
            {
                using (var db = new YOUREntities())
                {
                    //Build your record
                    var tableSchema = new List<SqlMetaData>(1)
                    {
                        new SqlMetaData("Id", SqlDbType.UniqueIdentifier)
                    }.ToArray();
                    //And a table as a list of those records
                    var table = new List<SqlDataRecord>();
                    for (int i = 0; i < model.elements.Count; i++)
                    {
                        var tableRow = new SqlDataRecord(tableSchema);
                        tableRow.SetGuid(0, model.elements[i]);
                        table.Add(tableRow);
                    }
                    //Parameters for your query
                    SqlParameter[] parameters =
                    {
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Structured,
                            Direction = ParameterDirection.Input,
                            ParameterName = "listIds",
                            TypeName = "[dbo].[GuidList]", //Don't forget this one!
                            Value = table
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier,
                            Direction = ParameterDirection.Input,
                            ParameterName = "createdBy",
                            Value = CurrentUser.Id
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output, // output!
                            ParameterName = "success"
                        },
                        new SqlParameter
                        {
                            SqlDbType = SqlDbType.NVarChar,
                            Size = -1,                             // "-1" equals "max"
                            Direction = ParameterDirection.Output, // output too!
                            ParameterName = "errorMessage"
                        }
                    };
                    //Do not forget to use "DoNotEnsureTransaction" because if you don't EF will start it's own transaction for your SP.
                    //In that case you don't need internal transaction in DB or you must detect it with @@trancount and/or XACT_STATE() and change your logic
                    await db.Database.ExecuteSqlCommandAsync(TransactionalBehavior.DoNotEnsureTransaction,
                        "exec GenerateInvoice @listIds, @createdBy, @success out, @errorMessage out", parameters);
                    //reading output values:
                    int retValue;
                    if (parameters[2].Value != null && Int32.TryParse(parameters[2].Value.ToString(), out retValue))
                    {
                        if (retValue == 1)
                        {
                            return Ok("Invoice generated successfully");
                        }
                    }
                    string retErrorMessage = parameters[3].Value?.ToString();
                    return BadRequest(String.IsNullOrEmpty(retErrorMessage) ? "Invoice was not generated" : retErrorMessage);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
