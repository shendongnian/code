     var jsonData = new
                {
                    Name = qry.Name,
                    Age = qry.Age,
                    Colors = (
                        from c in qry
                        select new
                        {
                            ColorID = c.ColorID,
                            Name = c.Name
                        }).ToArray()
                };
    
    return Json(jsonData, JsonRequestBehavior.AllowGet);
