        public ActionResult Index()
        {
            List<WebGrid> list = new List<WebGrid>();
            using (Web_INCAEntities dc = new Web_INCAEntities())
            {
                var v = (from a in dc.Cat_Proyecto
                         join b in dc.Cat_Pais on a.Id_Pais equals b.ID
                         join c in dc.Cat_estado on a.Id_Estado equals c.Id
                         select new WebGrid
                         {
                            ID = a.ID,
                            ID_kEY = a.ID_kEY,
                            Cliente = a.Cliente,
                            Tipo_servicio = a.Tipo_servicio,
                            Descripcion = a.Descripcion,
                            Contratista = a.Contratista,
                            INCA_PM = a.INCA_PM,
                            Importe_INCA = a.Importe_INCA,
                            Importe_Cliente =  a.Importe_Cliente,
                            calle = a.calle,
                            colonia = a.colonia,
                            Estado = c.Estado,
                            Pais = b.Pais
                         });
                list = v.ToList();
            }
    
    
            List<WebGrid> list_Usuario = new List<WebGrid>();
            using (Web_INCAEntities dc = new Web_INCAEntities())
            {
                var v = (from a in dc.Usuarios
                         select new WebGrid
                         {
                             Usuario = a.Usuario,
                             nombres = a.Nombres,
                             apellidos = a.Apellido_Paterno,
                             empresa = a.Area_Empresa,
                             estatus_Usuario = a.Estatus,
                             alcance = a.Id_Alcance
                         });
                list_Usuario = v.ToList();
            }
    list.AddRange(list_Usuario);
            return View("../Admin/Administrador", list);
        }
