csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMainMenu : MonoBehaviour
{
    // Variables
    private bool _isInMainMenu = false;
    public PlayerCameraMouseLook cammouselook;
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isInMainMenu)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Additive);
                PlayerCameraMouseLook.mouseLookEnable = false;
                cammouselook.enabled = true;
                
                // -- Code to freeze the game
            }
            else
            {
                SceneManager.UnloadSceneAsync(0);
                // -- Code to unfreeze the game
            }
            _isInMainMenu = !_isInMainMenu;
        }
    }
}
Take a look at the variable `_isInMainMenu` : it will track if you are in the main menu or not. Depends on the value, the **Escape key** will behave differently.
**Note :** I suggest you to type the current index of the scene in `LoadScene / UnloadSceneAsync`, unless you may want to change their index. In this scenario, type the scene name (Methods overload).
Now what I mean with `// -- Code to freeze the game` depends on your game :
* You can have a unique GameObject that contains all the others GameObjects your scene has, and `Enable / Disable` it
csharp
myBigGameObject.SetActive(true/*or false*/);
* Have a logic in MonoBehaviour to freeze the game while your in the main menu.
For example you can use the bool `_isInMainMenu` in **Update()** to stop them from doing their job ;
For example in this MonoBehaviour I created as an example :
csharp
public class ExampleMonoBehaviour : MonoBehaviour
{
    private void Update ()
    {
        if (_isInMainMenu)
            return;
        print("I'm running !");
    }
}
* Have a Collection (List<GameObject> as an example) that stores every `top hierarchy GameObjects` and enable/disable them all as needed to behave the same as above.
Depends on how your code is, there is many other options.
I will highly suggest you to do the *first* or *third* option, unless you have a better approach.
The thing is, if you want to go back to the main menu, it shouldn't be very expansive (loading time, memory usage, ...) so you can disable GameObject from the `main scene` (third point) to restore them back quickly when you leave the `main menu` without reloading the entire scene. This would lead you to use serialization and deserialization.
___
**Edited : Typo**
