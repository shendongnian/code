private Transform[] spawns = new Transform[3];
private GameObject[] objects = new GameObject[3];
For your UseCase it would probably be better to use a list as it does not require a fixed size:
private List<Transform> spawns = new List<Transform>();
private List<GameObject> objects = new List<GameObject>();
void Start()
{
    spawns.Add(spawn1);
    spawns.Add(spawn2);
    spawns.Add(spawn3);
    objects.Add(obj1);
    objects.Add(obj2);
    objects.Add(obj3);
}
