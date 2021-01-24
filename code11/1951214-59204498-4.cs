cs
private GameObject player;
void Start()
{
    player = GetComponent<GameObject>();
}
However, you can make a public variable as demonstrated in the other answer by Marcus.
But... If you want to find the game object at runtime, you can also do this:
cs
private GameObject player;
void Start()
{
    player = GameObject.FindWithTag("Player");
}
You just have to be certain to tag your player accordingly.  
    
