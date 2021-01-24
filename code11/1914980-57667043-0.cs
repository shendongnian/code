    var col = database.GetCollection<BsonDocument>("Revendas");
    var query =  col.Aggregate()
                    .Unwind("Clientes")
                    .Match(new BsonDocument(){ { "Clientes.Tokens.Token", "671bcaf806405e5d55419746a1b320cc729558fb" } })
                    .Project(new BsonDocument()
                        {
                            { "Codigo", "$Clientes.Codigo" },
                            { "Nome", "$Clientes.Nome" },
                            { "CNPJ", "$Clientes.CNPJ" },
                            { "CPF", "$Clientes.CPF" },
                            { "Tokens", "$Clientes.Tokens" }
                        });
    var doc = query.First();
