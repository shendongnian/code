    public class TextPrinting : MonoBehaviour {
    
         public Text nameText;
         public GameObject Alice;
    
         void say (Character ingamecharacter) {
             nameText.text = ingamecharacter.name;
             nameText.color = ingamecharacter.color;
         }
    
         void Start() {
             say(Alice.GetComponent<Character>());
         }
    }
