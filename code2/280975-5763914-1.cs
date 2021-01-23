    public ViewResult Students() {
       var menu = GetMenu();
       var students = Repository.Students();
       var model = new StudentPage {
         Menu = menu,
         Students = students
       }
       return View(model);
    }
