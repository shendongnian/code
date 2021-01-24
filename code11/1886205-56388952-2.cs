    public class Game : MonoBehaviour {
        
        [SerializeField]
        private Score _score;
        [SerializeField]
        private Plane _plane;
        
        public void Start () {
            // When you are destroyed let me know so I can add some points.
            _plane.OnDestroyed.AddListener(_score.AddPointsFor);
            _plane.Destroy();
        } 
    }
