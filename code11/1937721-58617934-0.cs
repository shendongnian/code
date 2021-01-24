[System.Serializable]
public struct testStruct{
    public int[] fieldArray;
    public int[] propertyArray{get;set;}
    [SerializeField]
    //[HideInInspector]
    private int[] propertyArray2;
    public int[] PropertyArray2 { get => propertyArray2; set => propertyArray2 = value; }
}
public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        testStruct data = new testStruct();
        data.fieldArray = new int[]{1,2,2,5};
        data.propertyArray = new int[]{1,1,1};
        data.PropertyArray2 = new int[]{2,2,2};
        Debug.Log(JsonUtility.ToJson(data));
        
    }
...
}
In the console fieldArray and propertyArray2(the private field) were both serialized, while data.PropertyArray was not serialized at all. Since it was not serialized, if the struct was loaded from json it would be initialized to its default value (null).
I hope this helps you with your problem. 
