    public class WheelTurning : MonoBehaviour
{
    float rpm=10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            turn(direction.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            turn(direction.right);
        }
        float vel = this.rpm * 2 * Mathf.PI / 60 * Time.deltaTime * Mathf.Rad2Deg;
        rotate(vel);
    }
    enum direction
    {
        left,
        right
    }
    void turn(direction dir)
    {
        Vector3 rot = this.gameObject.transform.rotation.eulerAngles;
        //rotates the wheels angle
        float rotation = dir == direction.left ? 20f : -20f;
        gameObject.transform.Rotate(new Vector3(0, rotation, 0), Space.World);
    }
    void rotate (float speed)
    {
        
        gameObject.transform.Rotate(0, speed, 0);
    }
