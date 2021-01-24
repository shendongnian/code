    (from e in Empresas
        where e.Segmento == "comida estranha"
        select new {
            e.NomeFantasia,
            e.RazaoSocial,
           var valor =    (from f in Feedbacks
                       where e.IdEmpresa == f.IdConsultoria || e.IdEmpresa == f.IdContratante
                       select f.IdFeedback).Count(),
           var total =    (from f in Feedbacks
                       where e.IdEmpresa == f.IdConsultoria || e.IdEmpresa == f.IdContratante
                       join r in Respostas on f.IdFeedback equals r.IdFeedback
                       group r by r.IdFeedback into x
                       select new {
                              x.Key
                           }).Count(),
        }).ToList()
 
