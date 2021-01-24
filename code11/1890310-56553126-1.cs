    public ActionResult Index(int? id)
    {
        InativosViewModel result = new InativosViewModel();
        using (Entidades db = new Entidades())
        {
            if (id != null)
            {
                result.Inativos = db.INATIVOS.Where(x => x.ID == id).FirstOrDefault();
            }
            result.EMPRESAS = db.EMPRESAS.ToList<EMPRESAS>();
            result.PLANOS_MEDICO = db.PLANOS_MEDICO.ToList<PLANOS_MEDICO>();
        }
        return View(result);
    }
