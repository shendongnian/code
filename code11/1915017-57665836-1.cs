    foreach (string line in lines)
    {
        if (line.Substring(0, 2) == "01")
        {
            ctrl = line.Substring(0, 2);
            TurbineModel newWell = new TurbineModel();
            newTurbine.Ctrl = ctrl;
    
            turbines.Add(newTurbine);
         }
         else if (line.Substring(0, 2) == "04")
         {
            var lastTurbine = turbines[turbines.Count - 1];
            //do what you need to do with the "04" record monthly data here
         }
    }
    
