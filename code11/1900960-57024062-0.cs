public class MyObject : MonoBehaviour
{
    public static MyObject Instance = null;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(Instance.gameObject);
            Instance = this;
        }
    }
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
And when you want to call your object you must use
MyObject x =  MyObject.Instance;
var rb = x.transform.GetComponent<Ridigbody2d>();
