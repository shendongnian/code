    public class CreateVM
    {
        private IUserRepository _repo;
        public CreateVM(IUserRepository repo)
       {
            _repo = repo;
       } 
       public IEnumerable<SelectListItem> AvailableUsers
       {
           get{
                return _repo.GetAll().Where(x=>x.isAvailable).Select(x=>new SelectListinItem{Text = x.UserName, Value = x.UserID});
              } 
       }
    }
