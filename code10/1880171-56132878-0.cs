       public ActionResult GetLaySimulation(string ids)
        {
            var idsStr = ids.Split(',');
            List<int> projectIDs = new List<int>();
            foreach (var item in idsStr)
            {
                if (!string.IsNullOrEmpty(item))
                    projectIDs.Add(int.Parse(item));
            }
            var layList = LayHelper.GetLayObjects(projectIDs.ToArray());
            return PartialView("_LaySimulation", layList);
        }
