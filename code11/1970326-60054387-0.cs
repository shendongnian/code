         //var query = context.Adresar.AsNoTracking();
            var query = context.Adresar.Select(x => string.Join(",", x.Ime, x.Prezime, x.Datarag + Environment.NewLine)).AsNoTracking();
            Response.ContentType = "application/json";
            Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("ime,prezime,datarag" + Environment.NewLine)); 
            foreach (var row in query)
                    {
                    await Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes(row));
                }
