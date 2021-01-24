public class Tiledata : MonoBehaviour
 {
     public int growTime;
     public int growLevel;
     public Tiledata(int growTime1, int growLevel1) {
        growTime = growTime1;
        growLevel = growLevel1;
     }
 }
And to add it in the game as a `Component` (that requires also a `GameObject` to be attached to).
Tiledata Test1 = new GameObject().AddComponent<Tiledata>();
  Debug.Log(Test1.growTime);
  foreach(Tiledata Tile in FindObjectsOfType<Tiledata>()) {
      Debug.Log("Test");
  } 
