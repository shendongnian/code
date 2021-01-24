    public class Snake : MonoBehaviour
    {
        public const float RADIUS = 1f; // distance between minions
        public const float MOVE_SPEED = 1f; // movement speed
    
        public Vector2 dir = Vector2.up; // movement direction
        public float headDist = 0f; // distance from path 'head' to leader (used for lerp-ing between points)
        public Path path = new Path(1); // path points
        public List<Minion> minions = new List<Minion>(); // all minions
    
        public Minion Leader => minions[0];
    
        void Awake()
        {
            path.Add(this.transform.position);
            AddMinion(new Knight());
        }
    
        void AddMinion(Minion minion)
        {
            // Initialize a minion and give it an index (0,1,2) which is used as offset later on
            minion.Init(minions.Count);
            minions.Add(minion);
            minion.MoveOnPath(path, 0f);
    
            // Resize the capacity of the path if there are more minions in the snake than the path
            if (path.Capacity <= minions.Count) path.Resize();
        }
    
        void FixedUpdate()
        {
            MoveLeader();
            MoveMinions();
        }
    
        void MoveLeader()
        {
            // Move the first minion (leader) towards the 'dir'
            Leader.transform.position += ((Vector3)dir) * MOVE_SPEED * Time.deltaTime;
    
            // Measure the distance between the leader and the 'head' of that path
            Vector2 headToLeader = ((Vector2)Leader.transform.position) - path.Head().pos;
    
            // Cache the precise distance so we can reuse it when we offset each minion
            headDist = headToLeader.magnitude;
    
            // When the distance between the leader and the 'head' of the path hits the threshold, spawn a new point in the path
            if (headDist >= RADIUS)
            {
                // In case leader overshot, let's make sure all points are spaced exactly with 'RADIUS'
                float leaderOvershoot = headDist - RADIUS;
                Vector2 pushDir = headToLeader.normalized * leaderOvershoot;
    
                path.Add(((Vector2)Leader.transform.position) - pushDir);
    
                // Update head distance as there is a new point we have to measure from now
                headDist = (((Vector2)Leader.transform.position) - path.Head().pos).sqrMagnitude;
            }
        }
    
        void MoveMinions()
        {
            float headDistUnit = headDist / RADIUS;
    
            for (int i = 1; i < minions.Count; i++)
            {
                Minion minion = minions[i];
    
                // Move minion on the path
                minion.MoveOnPath(path, headDistUnit);
    
                // Extra push to avoid minions stepping on each other
                Vector2 prevToNext = minions[i - 1].transform.position - minion.transform.position;
    
                float distance = prevToNext.magnitude;
                if (distance < RADIUS)
                {
                    float intersection = RADIUS - distance;
                    minion.Push(-prevToNext.normalized * RADIUS * intersection);
                }
            }
        }
    }
