    ...   // Standard Unity Namespaces can go here .  
    using UnityEngine.UI;
    
    public class MainMenuController : MonoBehaviour
    {
    
    private Canvas mainMenuCanvas;
    private bool showMenu; // Set this to true if it should be implemented at game open
    
    void Awake(){
      mainMenuCanvas = gameObject.GetComponent<Canvas>();
    }
    
    void Update(){
      if(Input.GetKeyDown(KeyCode.Return))
      {
        mainMenuCanvas.enabled = false;
        GlobalVars.G_START = true;
      }
    
      if(Input.GeKeyDown(KeyCode.Escape))
      {
        mainMenuCanvas.enabled = true;
        GlobalVars.G_START = false;
      }
    
    }
