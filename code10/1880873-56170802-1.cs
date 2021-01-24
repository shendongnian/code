    public JsonResult BindGrid()
    {            
        DataRow[] result;
    
        var output = (from c in entity.SaveImages.AsEnumerable()
          select new
          {
            ID = c.Id,
            ImageName = c.ImageName
          }).ToList();           
    
        var data = new { result = output };
    
        return Json(output, JsonRequestBehavior.AllowGet);
    }
