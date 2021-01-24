c#
[SerializeField] Gameobject clonePrefab; //You have to drag and drop a prefab from Unity here
List<Gameobject> clones=new List<Gameobject>();
void Start(){
    for(i=0,i<10,i++){
        clones.Add(Instantiate(clonePrefab));
    }
}
void Update(){
    if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for(i=0,i<clones.Count,i++){
                Destroy(clones[i]);
            }
        }
}
