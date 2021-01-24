        string ImageName = Path.GetFileName(uploadfile.FileName); 
        var url = Path.Combine(Server.MapPath("~/images"),ImageName); 
    //Save
        uploadfile.SaveAs(url);
        ent.Tbl_Haber.Add(haberobjesi);
        ent.SaveChanges(); 
        ViewBag.Sonuc = " Haber kaydedildi";
         return RedirectToAction("Index", new { id = haberobjesi.Id }); 
        }
