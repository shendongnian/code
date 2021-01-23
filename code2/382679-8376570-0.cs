    foreach (var item in invlist) {
 
         var tblRec = new TblRec(); 
         tblRec.FirstName = item.FirstName;
         tblRec.LastName = item.LastName;
         db.tblRec.AddObject(tblRec);                         
     }
     db.SaveChanges();
