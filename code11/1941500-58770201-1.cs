    public class MyScript: MonoBehaviour {
    
    
      void Start() {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://YOUR-FIREBASE-APP.firebaseio.com/");
    
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
      }
    
      public void NextButton()
      {
          // ported the variable names from your latest question
          mDatabaseRef.Child("messages").Child("message").SetValueAsync(HighlightedObject.GetComponent<OBClick>().name);
      }
    }
