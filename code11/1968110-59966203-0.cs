                public class NPCMovementNew : MonoBehaviour {
    public float speed = 2.0f; //movement speed
    public float idleTime = 1.0f;   //how much time does he spend idling
    public int dir; //where he's facing
    public bool idle; //false if a movement button is pressed
    public bool canMove = true; //to disable casual movement
    
    public GameObject token;    //to avoid collisions between entities while moving towards a tile
    Vector3 pos;
    List<int> directions;   //available directions
    CollisionScript cs;
    // Use this for initialization
    void Start () {
        cs = GetComponent<CollisionScript>();
        pos = transform.position;
        dir = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove && !idle)    //check if he can move
        {
            if (transform.position != pos)  //if he's not at the center of a square, he's not idling
            {
                idle = false;
                transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);   //move to that position
            }
            else   //here he decides to move
            {
                StartCoroutine(IdleThenMove(idleTime));
            }
        }
	}
    //function that goes idle for a certain time, then moves to an adiacent square
    IEnumerator IdleThenMove(float t)
    {
        idle = true;
        yield return new WaitForSeconds(t);
        //here it randomly chooses a direction and translates it to a position vector
        dir = ChooseDirection();
        switch (dir)
        {
            case 0:
                pos += Vector3.down;
                break;
            case 1:
                pos += Vector3.left;
                break;
            case 2:
                pos += Vector3.up;
                break;
            case 3:
                pos += Vector3.right;
                break;
            default:
                pos = transform.position;
                break;
        }
        idle = false;
        Instantiate(token, pos, Quaternion.identity);   //spawn token to occupy square
        transform.position= Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);   //move to that position
    }
    //checks how many directions are available and then chooses one of them randomly
    int ChooseDirection()
    {
        directions = new List<int>();
        //check the directions
        if (!cs.hitDown)
        {
            directions.Add(0);
        }
        if (!cs.hitLeft)
        {
            directions.Add(1);
        }
        if (!cs.hitUp)
        {
            directions.Add(2);
        }
        if (!cs.hitRight)
        {
            directions.Add(3);
        }
        //turn directions into an array and pick a random direction
        var array = directions.ToArray();
        directions.Clear();
        return array[Random.Range(0, (array.Length))];
    }
    }
