    public ActionResult Menu()
    {
        var model =
            from p in storeDB.Products.Include("Category").Include("Type")
            group p by p.Gender
            into genderGroup
            select new MenuObject
            {
                Gender = genderGroup.Key,
                Categories =
                (
                    from p2 in genderGroup
                    group p2 by p2.Category
                    into categoryGroup
                    select categoryGroup.Key
                ),
                Types =
                (
                    from p3 in genderGroup
                    group p3 by p3.Type
                    into typeGroup
                    select typeGroup.Key
                )
            };
        
        return View(model);
    }
    public class MenuObject
    {
        public string Gender { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Type> Types { get; set; }
    }
