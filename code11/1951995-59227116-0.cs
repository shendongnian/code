        public ActionResult DistanceMCalculate()
            {
                var result= db.Resource
                    .Where(p => p.ResourceTypeId == 1 && p.Latitude != null)
                    .Select(x => new { x.Id, x.Latitude, x.Longitude })
                    .ToList();
                
                return Json(result);
            }
