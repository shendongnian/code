    public ActionResult Index(int? id)
    {
        INATIVOS inaModel = new INATIVOS();
        using (Entidades db = new Entidades())
        {
            if (id != null)
            {
                inaModel = db.INATIVOS.Where(x => x.ID == id).FirstOrDefault();
            }
            ViewBag.Empresas = db.EMPRESAS.ToList<EMPRESAS>();
            ViewBag.PlanosMedico = db.PLANOS_MEDICO.ToList<PLANOS_MEDICO>();
        }
        return View(inaModel);
    }
