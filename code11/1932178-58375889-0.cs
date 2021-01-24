    public List<SelectListItem> Users { 
        get { 
            return Service.GetAll<User>().ToSelectList();
        }
    }
