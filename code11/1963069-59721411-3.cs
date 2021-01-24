    public void SetDataInObjects()
    {
        for (var j = 0; j < ObjList.objects.Count; j++)
        {
            // This actually stays the same for all inner iterations until j is changed
            // so keep it around as long as possible to save resources
            var serverObj = ObjList.objects[j].name;
            for (int k = 0; k < allObjs.Length; k++)  // Length is 10
            {                
                stCalc = uiMana.floorStats[k].GetComponent<StatesCalc>();
                // Also this stays the same until k is changed
                // so keep the reference around to save access calls
                var currentObj = allObjs[k];
                for (int m = 0; m < currentObj.floorObjs.Length; m++)  //Length is 80
                {
                    var localObj = currentObj.floorObjs[m].gameObject.name;
                    if (localObj == serverObj)
                    {
                        ObjManager curObjManger = allObjs[k].floorObjs[m].GetComponent<ObjManager>();
                        //Logic to set data in local objects
                    }
                }                
            }
        }
    }
