public class Control : MonoBehaviour
{
    private static int count = 0;
    public List<GameObject> cubes;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cubes[count].GetComponent<Rigidbody>().velocity = new Vector3(0f, 10f, 0f);
            count = (++count) % cubes.Count;
        }
    }
}
This script will need to be added to an empty GameObject; then you can fill the `cubes` list from the editor by dragging the cubes in it. The other cubes **do not** need the `Control` script.
Your scene graph will have these elements:
> -- Control (GameObject with Control script)
> 
-- Cube1
>
-- Cube2
> 
-- Cube3
