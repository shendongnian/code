        var connString = "mongodb+srv";
        var client = new MongoClient(connString);
        var database = client.GetDatabase("Base");
        var collection = database.GetCollection<UsuariosAcessos>("collection"); //Here you put you Model
        
        var filter = Builders<UsuariosAcessos>.Filter.Eq(x => x.PartnerId, cliente) 
            & Builders<UsuariosAcessos>.Filter.Eq(x => x.CD_CLIENTE, codCond);   
        
        var lista = collection.Aggregate().Match(filter).Project(x => new UsuariosAcessos
        {
              CD_CLIENTE = x.CD_CLIENTE,
              ID_ACESSO = x.ID_ACESSO,
              CD_ACESSO = x.CD_ACESSO,
              NOME = x.NOME,
              NU_TELEFONE = x.NU_TELEFONE,
              EMAIL = x.EMAIL,
              NU_KIPER_RF = x.NU_KIPER_RF,
              NU_KIPER_TAG = x.NU_KIPER_TAG,
              FG_KIPER_MOBILE = x.FG_KIPER_MOBILE,
              KEY_HASH = x.KEY_HASH
      }).ToList();
