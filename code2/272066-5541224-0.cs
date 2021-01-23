     string sQuery = @"INSERT INTO [ExpenseType]
                                          (
                                             [ExpenseTypeName]
                                            ,[Deleted]
                                            ,[IsTaxable]
                                            ,[UpdatedDate]
                                            ,[UpdatedUser]
                                            ,[ParentCategoryComponentID]
                                            ,[CategoryComponentID]
                                            ,[NLNominalAccountID]
                                            ,[SYSTaxCodeID]
                                          )
                                          VALUES
                                          (
                                             @ExpenseTypeName
                                            ,@Deleted
                                            ,@IsTaxable
                                            ,@UpdatedDate
                                            ,@UpdatedUser
                                            ,@ParentCategoryComponentID
                                            ,@CategoryComponentID
                                            ,@NLNominalAccountID
                                            ,@SYSTaxCodeID
                                          )
                                          SELECT SCOPE_IDENTITY() AS 'ID' ";
    
                        using ( SqlCommand oSqlCommand = new SqlCommand( sQuery ) )
                        {
                            oSqlCommand.Parameters.AddWithValue( "@ExpenseTypeName", this.ExpenseTypeName );
                            oSqlCommand.Parameters.AddWithValue( "@Deleted", this.Deleted );
                            oSqlCommand.Parameters.AddWithValue( "@IsTaxable", this.IsTaxable );
                            oSqlCommand.Parameters.AddWithValue( "@UpdatedDate", base.GetUpdatedDate() );
                            oSqlCommand.Parameters.AddWithValue( "@UpdatedUser", base.GetUpdatedUser() );
                            oSqlCommand.Parameters.AddWithValue( "@ParentCategoryComponentID", this.ParentCategoryComponentID );
                            oSqlCommand.Parameters.AddWithValue( "@CategoryComponentID", this.CategoryComponentID );
                            oSqlCommand.Parameters.AddWithValue( "@NLNominalAccountID", this.NLNominalAccountID );
                            oSqlCommand.Parameters.AddWithValue( "@SYSTaxCodeID", this.SYSTaxCodeID );
    
                            using ( DataTable dt = DataTier.ExecuteQuery( oSqlCommand ) )
                            {
                                if ( dt.Rows.Count == 1 )
                                {
                                    //Read the new ID from the record that has just been inserted
                                                                    string RecordID =  dt.Rows[ 0 ][ "ID" ].ToString();
                                }
                            }
                        }
