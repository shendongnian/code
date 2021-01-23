    public bool Save(WebClientLogin login, WebClient client)
            {
                var created = false;
    
                using (var transaction = new TransactionScope())
                {
                    try
                    {
         // insert WebClientLogin first
                        tablalogin.InsertOnSubmit(login);
                        dataContext.SubmitChanges();
        
         // insert WebClient second
                        client.WebClientLogin_id = login.Id;
                        tablacliente.InsertOnSubmit(client);
    
                        dataContext.SubmitChanges();
                        created = true;
                        transaction.Complete();
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
                return created;
            }
