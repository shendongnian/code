    db.Entry(page.Title).State = EntityState.Modified;
    db.Entry(page.Description).State = EntityState.Modified;
    
    db.Entry(page).State = EntityState.Modified;
    db.SaveChanges();
