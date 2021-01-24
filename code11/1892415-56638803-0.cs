[System.Serializable()]
public class MoneyHandlerData  //Note - no monobehaviour
{
    public int pickaxe = 0;
    public int nbDwarves = 1;
    public double moneyAccount = 10000;
    public double moneyPerSec = 500;
    public int bow = 0;
    public int nbElves = 0;
}
Now that this class is not a MonoBehaviour anymore you can't use it as a component, that's why you get ExtensionOfNativeClass error. You can keep it in the state of a monobehaviour though
public class MoneyHandler : MonoBehaviour
{
    MoneyHandlerData  data; //Serialize me
}
You can also make the save - load class not a MonoBehaviour, since it doesn't use any of its functionality. Not everything has to be a Component in Unity. You can make the functions static, so that you can access them from anywhere and just let them take in the object to be serialized as a parameter (e.g. the MoneyHandlerData object)
