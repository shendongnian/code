    public class FirebaseData : MonoBehaviour {
    
        void Start() {
            PlayerPrefs.SetString("test", "hello");    
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("HERE IS THE URL TO MY PROJECT");    
            TestRetrieve();
        }
        public void TestRetrieve() {   
            retrieve += onRetrieve;
            retrieve(this, EventArgs.Empty);
        }
        event EventHandler retrieve = delegate { };
        private async void onRetrieve(object sender, EventArgs args) {
            retrieve -= onRetrieve;
            try {
                DataSnapshot snapshot = await FirebaseDatabase.DefaultInstance.GetReference("users/").GetValueAsync();
                print("here");
                PlayerPrefs.GetString("test");
                print("there");
            } catch (Exception ex) {
                 // Handle the error here...
            }
        }
    }
