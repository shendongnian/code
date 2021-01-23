    Usuario user = _db.Usuario
                      .FirstOrDefault(x=>x.Nombre == model.UserName
                                     &&  x.Password == encripPassword);
    string sql = (user as ObjectQuery).ToTraceString(); //the SQL query generated.
    if(user==null)
    {
      //doesn't exist.
    }
