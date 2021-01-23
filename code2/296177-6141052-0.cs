    MyDataContext context = new MyDataContext("SomeConnectionString");
    
    var results = from a in context.AmenazasEstablecer
                  from c in context.ControlesEstablecer
                  from m in Matriz_Amenazas_ControlesEstablecer
                  where a.IdAmenaza == m.IdAmenaza && c.IdControl == m.IdControl
                  select new {
                      a.Amenaza,
                      c.Nombre,
                      c.Descripcion
                  });
