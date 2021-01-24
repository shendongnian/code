using UnityEngine;
public class GameManager: MonoBehaviour
{
    [SerializeField]
    private GameObject mainGame;
    public static GameObject MainGame {get;private set;}
    void Awake(){
        GameManager.MainGame = mainGame;
    }
}
Now you may refer to the `mainGame` object in your MainMenu script via `GameManager.MainGame`
