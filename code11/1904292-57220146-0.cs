    [HttpGet] public ActionResult GetActif(){
                    total = list.Count,
                    rows = (from u in list
                            select new
                            {
                                id = u.Id,
                                Name = u.sName,
                            }).ToArray()
                };
         return JsonData;
    }
