    using Firebase;
    using Firebase.Database;
    using Firebase.Unity.Editor;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class SetPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> checkpoints = new List<Transform>();
        private LineRenderer linerenderer;
        public Material TheLineMateriel;
    
    
        //Firebase 
        public static bool _ispressed = false;
        private string DATA_URL = "https://kataraproject-a233a.firebaseio.com/";
        private DatabaseReference reference;
        Positions playerInstance = new Positions();
        List<Vector3> tmpList = new List<Vector3>();
        public static string Json;
        bool liste_done = false;
        Vector3 newPosition;
        public List<Vector3> listOfPosition = new List<Vector3>();
        // Start is called before the first frame update
    
        private void Awake()
        {
            //FireBase
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATA_URL);
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        }
        void Start()
        {
    
            FirebaseDatabase.DefaultInstance.GetReference("Positions").GetValueAsync().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Debug.Log("No snapshot");
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    //Debug.Log("Snapshot:= " + task.Result.Value);
                    int i = 0;
                   
                    foreach (DataSnapshot user in snapshot.Children)
                    {
                        // IDictionary dictUser = (IDictionary)user.Value;
                        //Debug.Log(dictUser.Keys);
                        Positions client = JsonConvert.DeserializeObject<Positions>(user.GetRawJsonValue());
                        foreach (var item in client.Position)
                        {
                            newPosition.x = item.x;
                            newPosition.y = item.y;
                            newPosition.z = 0;
                            checkpoints[i].gameObject.SetActive(true);
                            checkpoints[i].position = newPosition;
                            i++;
    
                        }
                        //Debug.Log(user.GetRawJsonValue());
                    }
                    //DrawLine
                    GameObject lineObject = new GameObject();
                    this.linerenderer = lineObject.AddComponent<LineRenderer>();
                    this.linerenderer.startWidth = 0.05f;
                    this.linerenderer.endWidth = 0.05f;
                    this.linerenderer.positionCount = checkpoints.Count;
                    this.linerenderer.material = TheLineMateriel;
                }
    
            });
           
    
        }
       
        // Update is called once per frame
        void Update()
        {
            this.DrawLine();
        }
        private void DrawLine()
        {
    
            Vector3[] checkpointsArray = new Vector3[this.checkpoints.Count];
            
         
            for (int i = 0; i < this.checkpoints.Count; i++)
            {
                Vector3 checkpointPos = this.checkpoints[i].position;
                checkpointsArray[i] = new Vector3(checkpointPos.x, checkpointPos.y, 0f);
            }
            Vector3[] newPos = new Vector3[linerenderer.positionCount];
            this.linerenderer.SetPositions(checkpointsArray);
            linerenderer.GetPositions(newPos);
            if (_ispressed == true)
            {
    
                playerInstance.Position = newPos;
                writeNewPosition("1");
    
                _ispressed = false;
                Debug.Log("Saving is done");
            }
    
    
        }
        //Save Data in fireBase
        private void writeNewPosition(string positionId)
        {
    
            string json = JsonUtility.ToJson(playerInstance);
    
            reference.Child("Positions").Child(positionId).SetRawJsonValueAsync(json);
        }
        //Button to save Data
        public void PostPosition()
        {
            _ispressed = true;
        }
    
        public void NextScene()
        {
            SceneManager.LoadScene("PlayerSelmaNew");
        }
    
    }
