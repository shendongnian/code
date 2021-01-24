static bool created = false;
public bool Loading = true;
void Awake()
{
  if(!created)
  {
    DontDestroyOnLoad(this.gameObject);
    created = true;
  }
  else
  {
  Destroy(this.gameObject);
  }
}
void Update()
{
  if(Input.GetKeyDown(KeyCode.A) && LoadingOnce == true)
  {
    GameObject go = GameObject.Find("Cloner");
    Destroy(go);
    LoadingOnce = false;
    SceneManager.LoadScene("Home");
  }
}
