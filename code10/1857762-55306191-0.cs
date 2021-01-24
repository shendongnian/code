    var subjectIdResult = (from sId in db.SBanInfos where sId.SubjectId == id select sId.SubjectId).Single();
    var fileDetailsResult = (from fd in db.SBanFileDetails where fd.SubjectId == subjectIdResult select fd.Id).ToList();
            
    foreach(var fileId in fileDetailsResult)
    { 
        Guid guid = new Guid(fileId.ToByteArray());
        SBanFileDetail sBanFileDetail = db.SBanFileDetails.Find(guid);
            
        //Delete files from the file system
        var path = Path.Combine(Server.MapPath("~/pathto/myfiles/"), sBanFileDetail.Id + sBanFileDetail.Extension);
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
    }
    SBanInfo sBanInfo = db.SBanInfos.Find(id);
    db.SBanFileDetails
       .Where(p => p.SubjectId == id)
       .ToList()
       .ForEach(p => db.SBanFileDetails.Remove(p));
    db.SBanInfos.Remove(sBanInfo);
    db.SaveChanges();
    return RedirectToAction("Index");
