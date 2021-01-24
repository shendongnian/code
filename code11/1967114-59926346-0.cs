    Socios socio = _context.Socios.Include(s => s.Gerir).Include(s => s.Mensagem).Include(s => s.Participa).Include(s => s.PersonalTrainer).Include(s => s.Peso).Include(s => s.PlanosExercicios).FirstOrDefault(s => s.NomeUtilizador == user && s.Password == password);
            if (socio != null)
            {
                HttpContext.Session.SetString("Nome", socio.NomeUtilizador);
                HttpContext.Session.SetInt32("UserId", socio.Idsocio);
                HttpContext.Session.SetString("Perfil", "Socio");
            }
            Professores prof = _context.Professores.Include(p => p.MapaAulasGrupo).Include(p => p.Mensagem).Include(p => p.Peso).Include(s => s.PersonalTrainer).Include(p => p.PlanosExercicios).FirstOrDefault(p => p.Nome == user && p.Password == password);
            if (prof != null)
            {
                HttpContext.Session.SetString("Nome", prof.Nome);
                //set ProfessorId for Professores 
                HttpContext.Session.SetInt32("ProfessorId", prof.Idprofessor);
                HttpContext.Session.SetString("Perfil", "Professor");
            }
            Administrador admin = _context.Administrador.Include(a => a.Gerir).SingleOrDefault(a => a.Nome == user && a.Password == password);
            if (admin != null)
            {
                HttpContext.Session.SetString("Nome", admin.Nome);
                //set AdminId for Administrador 
                HttpContext.Session.SetInt32("AdminId", admin.Idadministrador);
                HttpContext.Session.SetString("Perfil", "Administrador");
            }
