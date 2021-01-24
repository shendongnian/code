    [ExecuteInEditMode]
    public class MyScript : MonoBehaviour
    {
      public int myValue;
      private int oldValue;
    
      void Update ()
      {
        if (oldValue != myValue)
        {
          MyScript[] objects = FindObjectsOfType<MyScript>();
    
          foreach(MyScript myObject in objects)
          {
            myObject.myValue = myValue
          }
    
          oldValue = myValue;
        }
      }
    }
