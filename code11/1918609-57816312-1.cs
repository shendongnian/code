    using System.Collections;
    using UnityEngine;
    
    // We start classes with capital letters in c# its a convention :)
    public class Cube : MonoBehaviour
    {
        // Same applies to public class fields & Properties
        // Marking a MonoBehaviour field as public will allow you to directly assign values to it
        // inside the editor
        public GameObject OriginalCube;
    
        // Same can be achieved with private fields using the serializefield attribute
        [SerializeField]
        private float cubeHeight = 1.0f;
    
        // In case you would like to store the duplicated cubes
        public List<GameObject> Cubes = new List<GameObject>();
    
        private void Awake()
        {
            // Adding the first cube to the list, i assume your cube is already in the scene
            Cubes.Add(OriginalCube);
        }
    
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            { 
                // We instantiate a new cube and add it to the list
                Cubes.Add(Instantiate(Cubes[Cubes.Count - 1]);
                // We ask the previous cube position (the one we copied)
                Vector3 previousCubePosition = Cubes[Cubes.Count - 2];
                // then we assign a new position to our cube raised by "1 unit" on the y axis which is the up axis in unity
                Cubes[Cubes.Count - 1].transform.position = 
                    new Vector3(previousCubePosition.x, previousCubePosition.y + cubeHeight, previousCubePosition.z);
            }
        }
    }
