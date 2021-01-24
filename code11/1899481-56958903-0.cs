C#
using UnityEngine.SceneManagement;
public class VictoryZone : MonoBehaviour {
    public void LoadNextLevel() {
        SceneManager.LoadScene(1);
    }
    void OnTriggerEnter2D(Collider2D collider) {
        LoadNextLevel();
    }
}
Note: you might also need to check the GameObject associated with `collider` to make sure that it's a player, and not an enemy or something (if, hypothetically, you had enemies or projectiles or other objects with colliders moving into the victory zone).
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
