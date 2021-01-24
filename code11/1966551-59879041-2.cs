    [WebGet(UriTemplate = "/GetNameAndSurname/{login}")]
    public ActionResult GetNameAndSurname(string login){
       urDB.Where(x=>x.login == login).Select(s=> new Members_Model {
          Name = s.Name,
          Surname = s.Surname
       });
    .. and some stuff u want too... than return...
    }
