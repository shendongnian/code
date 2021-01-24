    using UnityEngine;
    public class Example: MonoBehaviour
    {
    /*this holds reference to the gameobject it self it needs to be static otherwise each 
    instance would have a reference to it self.*/
    public static Example instance = null;
    //a value (can be whatever)
    public float counter = 0.0f;
    void Start()
    {
        /* if there an already existing Example gameobject (instance isn't null) destroy 
        the others*/
        if (instance != null)
        {
            Destroy(gameObject);
        }
        /*the very first instance is kept as the instance and will run through all the 
        scenes keeping all values until the program is shutdown*/
        else
        {
            DontDestroyOnLoad(gameObject); /*this will keep the gameobject "alive" through all scenes*/
            instance = this; /*instance reference to this gameobject (the first one to exist)*/
        }
    }
    void Update()
    {
      /*adding passing time to counter again this can be any behaviour you want and will 
      keep running through scenes AND the values wont be reset until you shutdown the 
      program*/
      counter += Time.deltaTime;
    }
    }
