    public class Shop : MonoBehaviour {
        AllData allData = new AllData();
        private SaveSystem saveSystem = new SaveSystem();
    
        public Text milkText;
    
        public void Start() {
            // assigns '-1' if data was not found;
            var loadedData = saveSystem.Load();
            allData.milk = (int) (loadedData == null ? -1 : loadedData.milk);
    
            milkText.text = allData.milk.ToString();
        }
    
        public void Update() {
            if (Input.GetKeyDown(KeyCode.K)){
                TestSaving();
            }
    
            if (Input.GetKeyDown(KeyCode.J)) {
                TestAddingMilkValue();
            }
    
            if (Input.GetKeyDown(KeyCode.I)) {
                TestLoadingMilkValue();
            }
    
            #region Local_Function
            void TestSaving() {
                Debug.Log("SAVING...");
                saveSystem.Save(this.allData);
            }
    
            void TestAddingMilkValue() {
                Debug.Log("ADD...");
                ++allData.milk;
                milkText.text = allData.milk.ToString();
            }
    
            void TestLoadingMilkValue() {
                Debug.Log("LOADING...");
                var loadedData = saveSystem.Load();
                allData.milk = (int)(loadedData == null ? -1 : loadedData.milk);
    
                milkText.text = allData.milk.ToString();
            }
            #endregion
        }
    
    }
