    [HttpGet]
    public ActionResult GetNumberDays(string mieciacValue, int rokValue)
    {
        var liczbaDni = _ecpContext.Miesiace.Where(x => x.Rok == rokValue && x => x.Miesiac == miesiacValue).Select(i => new
        {
             ObecnaIloscDni = i.IloscDni
        });
    
        return null;
    }
