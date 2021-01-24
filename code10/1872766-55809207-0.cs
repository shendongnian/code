    public class SuccessViewModel 
    {
        public string Name {get;set;}
    }
    public ActionResult Success(Login log)
    {
        using (var dbs = new guruEntities())
        {
        var check = dbs.Logins.FirstOrDefault(x => x.Name == log.Name && x.Password == log.Password);
            var vm = new SuccessViewModel { Name = log.Name };
            return View(vm);
        }
    }
