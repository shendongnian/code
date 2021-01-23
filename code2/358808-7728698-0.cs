    sqlconnection con=new sqlconnection(constr);
    sqltransaction tran=con.begintransaction();
                           try {      
                                CallSPMethod1(tran);
                                CallSPMethod2(tran);
                                CallSPMethod3(tran);
    
                                
                                 
                                //Commit all steps in transaction scope
                               tran.commit
                                transactionStatus = 1;
                            }
                            catch{
                             tran.rollback();
                                  }
        }
                      
        public static void CallSPMethod1(sqltransaction tr)
                {
                    try
                    {
                        sqlconnection con=tr.connection;
                        {
                         //do ur work here
                            }
                     }
                     catch{}
                  }
