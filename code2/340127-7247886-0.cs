    public IEnumerable<IMyType> All() {
      var query = _connection.Query("SELECT * FROM [table]");
      return query.Select(o => _myTypeFactory.Create((Object)o)); //cast dynamic type to Object
    }
    ...
    public IMyType Create(Object o) {//Remove dynamic from signature
       dynamic d = o;
       return Create((String) d.Code, (Int32) d.KeyID);
    }
