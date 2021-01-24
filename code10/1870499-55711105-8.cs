    public class SwipeControls : MonoBehaviour
    {
        // Flag for ignoring input until current animation finished
        private bool routineRunning;
        // Configure in the Inspector distance to swipe
        // in unity units
        [SerializeField] private float swipeDistance = 5;
        // configure this in the Inspector
        // How long should the swiping take in seconds
        [SerializeField] private float swipeDuration = 1;
        private Vector3 _startpos;  // start position
        private Vector3 _endpos; //end position
        public int pozioma = 0;
        public int pionowa = 0;
        private Animator _anim;
        private void Start()
        {
            GetComponent<Animator>();
        }
        private void Update()
        {
            // Ignore any Input while a routine is running
            if (routineRunning) return;
            foreach (var touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _startpos = touch.position;
                        _endpos = touch.position;
                        break;
                    case TouchPhase.Moved:
                        _endpos = touch.position;
                        break;
                    case TouchPhase.Ended:
                        if (Mathf.Abs(_startpos.y - _endpos.y) > Mathf.Abs(_startpos.x - _endpos.x))
                        {
                            if (_startpos.y - _endpos.y > 100 && pionowa > -1) //swipe down
                            {
                                pionowa--;
                                StartCoroutine(MoveSmooth(Vector3.up * -1, swipeDuration));
                                _anim.SetTrigger("Flydown");
                            }
                            else if (_startpos.y - _endpos.y < -100 && pionowa < 1) //swipe up
                            {
                                pionowa++;
                                StartCoroutine(MoveSmooth(Vector3.up, swipeDuration));
                                _anim.SetTrigger("Flyup");
                            }
                        }
                        else
                        {
                            if (_startpos.x - _endpos.x > 100 && pozioma > -1) //swipe left
                            {
                                pozioma--;
                                StartCoroutine(MoveSmooth(Vector3.forward * -1, swipeDuration));
                                _anim.SetTrigger("Flyleft");
                            }
                            else if (_startpos.x - _endpos.x < -100 && pozioma < 1) //swipe right
                            {
                                pozioma++;
                                StartCoroutine(MoveSmooth(Vector3.forward, swipeDuration));
                                _anim.SetTrigger("Flyright");
                            }
                        }
                        break;
                }
            }
        }
        private IEnumerator MoveSmooth(Vector3 direction, float duration)
        {
            routineRunning = true;
            var currentPosition = transform.position;
            var targetPosition = currentPosition + direction * swipeDistance;
            var timePassed = 0f;
            do
            {
                // Additionally add some ease in and out to the movement to get 
                // even smoother movement
                var lerpFactor = Mathf.SmoothStep(0, 1, timePassed / duration);
                // Interpolate the position between currentPosition and targetPosition
                // using the factor between 0 and 1
                transform.position = Vector3.Lerp(currentPosition, targetPosition, lerpFactor);
                // increase by time since last frame
                timePassed += Time.deltaTime;
                // let this frame render and go on from
                // here in the next frame
                yield return null;
            } while (timePassed <= duration);
            // To avoid over or undershooting in the end set a fixed value
            transform.position = targetPosition;
            routineRunning = false;
        }
    }
