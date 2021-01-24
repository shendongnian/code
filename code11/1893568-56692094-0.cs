    public float MinimalYLocation; 
    GameObject[] Objects;
    
    void Start () {
      Scene scena = SceneManager.GetActiveScene();
     Objects = scena.GetRootGameObjects(); 
    }
    void Update () {
    foreach (GameObject gobject in Objects)
      {
     float Height = gobject.transform.position.y;
     if (Height < MinimalYLocation){
      Destroy(gobject);
     Scene scena = SceneManager.GetActiveScene();
      Objects = scena.GetRootGameObjects();
       }
      }
    } 
