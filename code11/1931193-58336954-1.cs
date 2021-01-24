    public class GameObjectDictionary
    {
    
        private Dictionary<GameObject, List<GameObject>> internalDictionary = new Dictionary<GameObject, List<GameObject>>();
    
        public void Add(GameObject key, GameObject value)
        {
            if (this.internalDictionary.ContainsKey(key))
            {
                List<GameObject> list = this.internalDictionary[key];
                list.Add(value);
                
            }
            else
            {
                List<GameObject> list = new List<GameObject>();
                list.Add(value);
                this.internalDictionary.Add(key, list);
            }
        }
    
        GetValue(GameObject key){
            return(internalDictionary[key]);
        }
    
    }
