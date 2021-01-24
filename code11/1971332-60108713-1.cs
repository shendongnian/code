    [HttpPost]
    public ActionResult PartialTabelaEcp(string userDate)
    {
        int liczbaDni = 2;
        int numerMiesiaca = 6;
        int numerRoku = 12;
        userDaty_Model userDaty = new userDaty_Model();
        userDaty.liczbaDniM = liczbaDni;
        userDaty.numerRokuM = numerMiesiaca;
        userDaty.numerMiesiacaM = numerRoku;
        var data = new ParentView()
        {
            Model4 = userDaty
        };
        return PartialView("~/Views/Home/_TabelaEwidencja.cshtml", data);
    }
    
