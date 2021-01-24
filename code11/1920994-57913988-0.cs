    public class Shop : MonoBehaviour
    {
        private SaveSystem saveSystem = new SaveSystem();
        AllData allData = new AllData();
    
        public Start(){
            saveSystem.Load();
         }
    
         public Update(){
            saveSystem.Load();
          }
    }
