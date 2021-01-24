    public class scoreCount : MonoBehaviour 
    {
        [Header("Components")]
        public Text countText;
    
        [Header("Prefabs")]
        public DestructableObject Egg_000;
        public DestructableObject Barrel_000;
        public DestructableObject Cube01_000;
    
        // I didn't see what those are used for
        /*
        public int eggCount;
        public int barrelCount;
        public int cubeCount;
        */
    
        [Header("amount of objects destroyed")]
        public int barrelAmount;
        public int eggAmount;
        public int cubeAmount;
    
        // Simply adjust those in the inspector as well and give them default values
        [Header("points values")]
        [SerializeField] private int egg = 100;
        [SerializeField] private int barrel = 75;
        [SerializeField] private int cube = 200;
    
        // Will be 0 by default anyway
        private int count;
    
        // Initializing points of each object
        private void Start () 
        {
            // Only thing needed to be set in Start
            // though even this you could simply do in that Text component already
            countText.text = "Score: " + count.ToString ();
        }
    
        // Called by the DestructableObjects when destroyed
        public void ObjectsDestroyed(DestructableType type)
        {
            // I didn't know which values you really need in the end
            // actually the lines with count += xyz; would be enough I guess
            switch(type)
            {
                case Egg:
                    eggCount += egg;
                    eggAmount++;
                    count += egg;
                    break;
    
                case Barrel:
                    barrelCount += barrel;
                    barrelAmount++;
                    count += barrel;
                    break;
    
                case Cube:
                    cubeCount += cube;
                    cubeAmount++;
                    count += cube;
                    break;
            }
    
            countText.text = "Score: " + count.ToString();
        }
    }
