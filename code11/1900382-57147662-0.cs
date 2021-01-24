                Thank you for your responses: this is a controller:
                
                    public async Task<JsonResult> GetPiePercentage(string param)
                    {
                
                        var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>> (param);
                
                        var cgList = Json(await GetGeneralConditionsPercentage(parameters));
                
                        return Json(new { Cg = cgList});
                
                    }
    public async Task GetGeneralConditionsPercentage(Dictionary param) { 
        DashBoardGeneralConditionViewModel listGC = new DashBoardGeneralConditionViewModel();
                 var tmp = await GetProjectsByRole(c => c.GeneralCondition,param); 
                 listGC.Percentages = tmp.Percentages;
             listGC.ProjectGroups = tmp.ProjectGroups; 
            listGC.BackGroundColors = tmp.BackGroundColors;
             var projectGroups = listGC.ProjectGroups; 
            var sum = projectGroups.Sum(item => item.Count);
    listGC.Percentages = projectGroups.ConvertAll(x => Math.Round((x.Count * 100), 2, MidpointRounding.AwayFromZero) / sum); 
            listGC.GeneralConditions = projectGroups.Select(x => x.Filter).ToList();
             var counttype = listGC.GeneralConditions.Count(); 
            listGC.BackGroundColors = setColorsList(counttype);
             return listGC; 
            } 
            private List setColorsList(int filterNum) { 
            List Colors = new List() { "#000066", "#006600", "#ffff00", "#ff0000", "#000099", "#00cc00", "#cc9900", "#ff0066", "#00ccff", "66ff99", "#663300", "#993333" };
             List tmpColors = new List();
             for (int i = 0; i < filterNum; i++) 
            { 
            tmpColors.Add(Colors[i]); 
            } 
            return tmpColors;
             }
