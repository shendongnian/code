    public class levelgen : MonoBehaviour
    {
        // You can declare a public field within a method
        // so move it to class scope
        // When dealing with int values rather use Vector3Int to avoid rounding errors
        public Vector3Int spawn = new Vector3(-2, 0, 9);
        public GameObject[] templates;
        // Update is called once per frame
        void Update()
        {
            // Here NOTE that for int parameters the second argument is "exclusiv"
            // so if you want correct indices you should always rather use
            int rand = Random.RandomRange(0, templates.Length);
            Instantiate(templates[rand], spawn1, Quaternion.identity);
            spawn += new Vector3Int(0, 0, 20);
        }
    }
    
