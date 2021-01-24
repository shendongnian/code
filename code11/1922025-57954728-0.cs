    using Firebase;
    using Firebase.Database;
    using Firebase.Extensions;
    using Firebase.Unity.Editor;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    
    private static bool created = false;
    
    // the belowing code is used for changing the scene without losing the script
        void Awake()
        {
            if (!created)
            {
                DontDestroyOnLoad(this.gameObject);
                created = true;
                Debug.Log("Awake: " + this.gameObject);
            }
        }
    	
    public class NewBehaviourScript : MonoBehaviour
    {
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    protected bool isFirebaseInitialized = false;
    // Start is called before the first frame update
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://frim-exam.firebaseio.com/");
        if (app.Options.DatabaseUrl != null)
            app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        StartListener();
        isFirebaseInitialized = true;
    }
    void StartListener()
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("Leaders")
      .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
              // Do something with snapshot...
              Debug.Log("Done!");
              SceneManager.LoadSceneAsync("Scene2");
              Debug.Log("Done!!!");
          }
        });
    }
    }
