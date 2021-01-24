    public class TimeController : MonoBehaviour {
            public const string DateChanged = "DateChanged";
            [Header("Settings")]
            [SerializeField] private Date date;
            [SerializeField, Range(1, 10)] private float timeScale = 1f;
            [SerializeField, Range(2, 32)] private int fastForwardModifier = 4;
            [SerializeField] private bool paused;
            [SerializeField] private bool fastForwarding;
            [Header("Properties")]
            [SerializeField, ReadOnly] private int totalDaysPassed;
    
            public bool Paused { get { return paused; } }
            public bool FastForwarding { get { return fastForwarding; } }
    
            private float timer;
    
            private void OnEnable() {
                date = new Date();
            }
    
            private void Start() {
                InitializeTimer();
            }
    
            private void InitializeTimer() {
                timer = timeScale;
            }
    
            private void Update() {
                AdvanceTime();
            }
    
            private void AdvanceTime() {
                if(paused) return;
                timer -= Time.deltaTime * (fastForwarding ? fastForwardModifier : 1);
                if(timer <= 0) {
                    timer += timeScale;
                    OnDayPassed();
                }
            }
    
            private void OnDayPassed() {
                totalDaysPassed++;
                date.AdvanceDay();
                this.PostEvent(DateChanged, new OnDateChanged(date));
            }
    
            public void PauseOrResume() {
                paused = !paused;
            }
        }
    
        public class OnDateChanged : EventData {
            public Date Date { get; private set; }
    
            public OnDateChanged(Date date) {
                Date = date;
            }
        }
