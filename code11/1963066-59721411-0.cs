    public void SetDataInObjects()
    {
        for (var j = 0; j < ObjList.objects.Count; j++)
        {
            for (int k = 0; k < allObjs.Length; k++)  // Length is 10
            {                
                stCalc = uiMana.floorStats[k].GetComponent<StatesCalc>();
                for (int m = 0; m < allObjs[k].floorObjs.Length; m++)  //Length is 80
                {
                    var serverObj = ObjList.objects[j].name;
                    var localObj = allObjs[k].floorObjs[m].gameObject.name;
                    if (localObj == serverObj)
                    {
                        ObjManager curObjManger = allObjs[k].floorObjs[m].GetComponent<ObjManager>();
                        //Logic to set data in local objects
                    }
                }                
            }
        }
    }
