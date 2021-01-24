csharp
public class AudioManager : MonoBehaviour
{
    //Create a static AudioManager that will hold the reference to this instance of AudioManager
    public static AudioManager Instance;
    public Sound[] sounds;
    //Assign Instance to the instance of this AudioManager in the constructor
    AudioManager()
    {
        Instance = this;
    }
    // Rest of the AudioManager code
}
Doing it like this, and using the rest of your code also works for me.
