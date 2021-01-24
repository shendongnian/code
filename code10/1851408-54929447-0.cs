     //We create a class with the Serializable attribute and stock the name and size of our GameObject 
           
    [Serializable]
        public class SzModel
        {
            public string modelName;
            public Vector3 modelSize;
        }
    
    //we have to import our .jslib method into our C# (see below)
        [DllImport("__Internal")]
        private static extern void UpdateModel(string model);
    //We use our dummy class to create a JSON parseable list of those objects
        void WallsList()
        {
            List<SzModel> szModelList = new List<SzModel>();
            foreach (var item in goList)
            {
                SzModel newWall = new SzModel();
                newWall.modelName = item.Name;
                newWall.modelSize = item.Size;
                szModelList.Add(newWall);
            }
    
            UpdateModel(JsonHelper.ToJson<SzModel>(szModelList.ToArray(), true));
        }
    
    //We create an helper class to be able to use JsonUtility on list
    //code can be found here -> https://stackoverflow.com/a/36244111/11013226
