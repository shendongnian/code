public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get => instance; }
    int levelNum = 1;
    public int LevelNum { get => levelNum; }
    private void Awake()
    {
        //Check to see if an instance of the LevelManager already exists.
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameobject);
    }
    public void LevelComplete()
    {
        levelNum++;
    }
}
As long as the above code is attached to a gameobject in your scene, you can call the following from another gameobject's script. You will notice that I encapsulate levelNum and instance. This is to enforce good practice in my other code. I know that the only script that can modify levelNum or instance is LevelManager, so I won't accidentally break something by changing one of those values in another script accidentally.
Be careful to only put the above script on a gameobject that is allowed to persist between scenes. I like to create an empty "Singletons" gameobject that just holds my singletons.
Example usage when defeating the final boss (if that's a way to beat your levels):
void BossDefeated()
{
    LevelManager.Instance.LevelComplete();
}
Example usage when checking to see if a portal can be opened:
int portalNum = 3;
bool CheckPortal()
{
    if(LevelManager.Instance.LevelNum >= portalNum)
        return true;
    return false;
}
  [1]: https://github.com/ErikOverflow/YardDefender/wiki/Saving-Game-Data-to-SQLite
