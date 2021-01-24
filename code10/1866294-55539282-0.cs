     ApplicationDbContext db = new ApplicationDbContext();
        
                // GET: Solicitudes
                public ActionResult Index()
                {
                    return View();
                }
        
                public ActionResult Index2()
                {
                    return View(db.Solicitudes.ToList());
                }
        
                //Get
                public ActionResult Solicitud()
                {
                    return View();
                }
        
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Solicitud(Solicitudes s)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {                 
                           
                            s.FechaFinal = DateTime.Now;
                            s.FechaYHoraSolicitud = DateTime.Now;
                            s.Id = "e17cba68-0a0b-4d6e-abaf-8026cb91fcd1";
                            s.fk_tipo_transaccion = 3;
                            s.fk_estado_solicitud = 1;
                            db.Solicitudes.Add(s);
                            db.SaveChanges();
                            ViewBag.Message = "Solicitud guardada";
                            ModelState.Clear();
                            return RedirectToAction("Index2");
                        }
                        return View("ModelStateError");
                    }
                    //catch
                    catch (Exception ex)
                    {
                        //throw ex;
                        Console.WriteLine(ex.Message);
                        return View("Error");
                    }
                } 
    
           
