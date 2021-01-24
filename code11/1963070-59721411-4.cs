    public void SetDataInObjects()
    {
        foreach(var serverObj in ObjList.objects)
        {
            var serverName = serverObj.name;
            for (int k = 0; k < allObjs.Length; k++)  // Length is 10
            {                
                stCalc = uiMana.floorStats[k].GetComponent<StatesCalc>();
                // Also this stays the same until k is changed
                // so keep the reference around to save access calls
                var currentObj = allObjs[k];
                foreach (var floorObj in currentObj.floorObjs)  //Length is 80
                {
                    if (localObjName.Equals(serverName))
                    {
                        var curObjManger = floorObj.GetComponent<ObjManager>();
                        //Logic to set data in local objects
                    }
                }                
            }
        }
    }
