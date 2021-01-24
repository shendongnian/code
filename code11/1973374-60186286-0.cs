    using (var db = new testEntities())
    {
        (from m in db.multicols
              where m.ColB != null && m.ColC != null //Dont pull if both columns are null
              select m).ToList().ForEach( m =>
              {
                  m.ColB = String.IsNullOrEmpty(m.ColB) ? m.ColB : $"-{m.ColB}-";
                  m.ColC = String.IsNullOrEmpty(m.ColC) ? m.ColC : $"-{m.ColC}-";
               });
    
        db.SaveChanges();
    }
