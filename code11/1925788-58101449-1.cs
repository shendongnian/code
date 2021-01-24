    public class levelgen : MonoBehaviour
    {
        // You can declare a public field within a method
        // so move it to class scope
        public Vector3 spawn = new Vector3(-2, 0, 9);
        public GameObject[] templates;
        // Update is called once per frame
        void Update()
        {
            // Here NOTE that for int parameters the second argument is "exclusiv"
            // so if you want correct indices you should always rather use
            int rand = Random.RandomRange(0, templates.Length);
            // I will just assume a typo and use spawn instead of spawn1
            Instantiate(templates[rand], spawn, Quaternion.identity);
            spawn += new Vector.forward * 20;
        }
    }
    
