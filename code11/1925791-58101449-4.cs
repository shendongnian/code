    public class levelgen : MonoBehaviour
    {
        // You can not declare a public field within a method
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
            spawn.z += 20;
            // Or I would prefer since this works in general
            // Vector3.forward is a shorthand for writing new Vector3(0, 0, 1)
            // and this works in general
            spawn += Vector3.forward * 20;
            // you can e.g. NOT use
            //transform.position.z += 20
            // but only
            //transform.position += Vector3.forward * 20;
        }
    }
