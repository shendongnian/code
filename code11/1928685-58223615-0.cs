[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data", order = 1)]
public class PlayerData : ScriptableObject 
{
    public string name;
}
public class NameInput : Monobehaviour
{
    public InputField fInput;
    public PlayerData playerData;
    public void NameSubmission()
    {
        playerData.name = fInput.text;
    }
}
public class Character : Monobehaviour
{
    public PlayerData playerData;
    public void Start()
    {
        Debug.Log(playerData.name);
    }
}
When you create a PlayerData ScriptableObject in your assets folder, you can then drag it onto any Character or NameInput GameObject's inspectors in your scene. The data now lives inside of the PlayerData asset object, rather than inside the scope of the scene. Please note that this does not persist the data outside of runtime, so you cannot close and restart the game and expect the name to persist. 
