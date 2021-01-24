    [CreateAssetMenu(fileName = "GlobalVariables", menuName = "ScriptableObject: global variables")]
         public class GlobalVariable: ScriptableObject {
             public int time; 
        }
 
------------------------
    public class TimeCount {
    
        public GlobalVariable variableStorage;
        
            public void Update() {
                variableStorage.time = Time.time;
            }
         }
