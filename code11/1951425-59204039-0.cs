    // all enemy types must implement the following
    public interface IEnemy {
        string EnemyName { get; }
        float EnemyHealth { get; }
        void Move ();
    }
    
    // abstract base class for common functionality
    public abstract class Enemy : IEnemy {
        protected float speed = 0.1f;
    
        public string EnemyName { get; protected set; }
        public float EnemyHealth { get; protected set; }
    
        public virtual void Move () {
            Debug.Log ($"{EnemyName} moving at {speed}");
        }
    }
    
    public class Slime : Enemy {
        public Slime () {
            speed = 0.1f;
            EnemyName = "Slimer";
            EnemyHealth = 100f;
        }
    
        public override void Move () {
            Debug.Log ($"{EnemyName} moving at {speed}");
        }
    }
    
    public class Flaz : Enemy {
        public Flaz () {
            speed = 0.5f;
            EnemyName = "Flaz";
            EnemyHealth = 50f;
        }
    
        public override void Move () {
            Debug.Log ($"{EnemyName} moving at {speed}");
        }
    }
    
    public class Test : MonoBehaviour {
        readonly List<IEnemy> Enemies = new List<IEnemy> ();
    
        void Start () {
            var slimer = new Slime ();
            Debug.Log ($"{slimer.EnemyName} initialized with health of {slimer.EnemyHealth}");
            slimer.Move ();
    
            var flaz = new Flaz ();
            Debug.Log ($"{flaz.EnemyName} initialized with health of {flaz.EnemyHealth}");
            flaz.Move ();
    
            Enemies.Add (slimer);
            Enemies.Add (flaz);
    
            Debug.Log ($"Added {Enemies.Count} enemies");
        }
    }
