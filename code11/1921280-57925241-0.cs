    var x = db.childobjects.Where(c => c.ID == cildobject.ID).FirstOrDeafult();
    If (x != null) {
    // then make changes to existing (variable x)
    }
    
    else {
    db.cildobjects.Add(childobject)
    }
    
    db.SaveChanges();
