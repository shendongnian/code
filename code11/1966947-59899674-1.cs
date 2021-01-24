    public enum Axis
    {
        X,
        Y
    }
    public enum AxisDirection
    {
        Right,
        Left,
        Up,
        Down
    }
    public class DoubleTap : MonoBehaviour
    {
        private const float translationSpeedX = 20;
        private const float translationSpeedY = 20;
        private const  float maxKeyDownTime = 0.2f;
        private const  float maxKeyUpTime = 0.2f;
        private const  float delayBetweenDoubleTaps = 0.4f;
       
        private Dictionary<Axis, string> axisName = new Dictionary<Axis, string>
        {
            {Axis.X, "Horizontal"},
            {Axis.Y, "Vertical"}
        };
        private Dictionary<Axis, AxisDirection> axisPositive = new Dictionary<Axis, AxisDirection>
        {
            {Axis.X, AxisDirection.Right},
            {Axis.Y, AxisDirection.Up}
        };
        private Dictionary<Axis, AxisDirection> axisNegative = new Dictionary<Axis, AxisDirection>
        {
            {Axis.X, AxisDirection.Left},
            {Axis.Y, AxisDirection.Down}
        };
        private Vector3 playerPosition;
        private bool doubleTapped = false;
        private Dictionary<AxisDirection, bool> axisFirstDown = new Dictionary<AxisDirection, bool>();
        private Dictionary<AxisDirection, bool> axisFirstUp = new Dictionary<AxisDirection, bool>();
        private Dictionary<AxisDirection, bool> axisPrevDown = new Dictionary<AxisDirection, bool>();
        // Start is called before the first frame update
        private void Start()
        {
            // setup dictionaries
            foreach (var axis in (AxisDirection[])Enum.GetValues(typeof(AxisDirection)))
            {
                axisFirstDown.Add(axis, false);
                axisFirstUp.Add(axis, false);
                axisPrevDown.Add(axis, false);
            }
            playerPosition = transform.position;
            StartCoroutine(KeyInputBuffer());
        }
        // Update is called once per frame
        private void Update()
        {
            //Take keyboard input and translate the player in X and Y directions
            playerPosition.x += UnityEngine.Input.GetAxis("Horizontal") * translationSpeedX * Time.deltaTime;
            playerPosition.x = Mathf.Clamp(playerPosition.x, -100, 100);
            playerPosition.y += UnityEngine.Input.GetAxis("Vertical") * translationSpeedY * Time.deltaTime;
            playerPosition.y = Mathf.Clamp(playerPosition.y, -100, 100);
            transform.position = playerPosition;
            foreach (var axis in (Axis[])Enum.GetValues(typeof(Axis)))
            {
                // positive
                if (axisFirstDown[axisPositive[axis]] && Input.GetAxisRaw(axisName[axis]) > 0)
                {
                    Debug.Log($"Double Tap {axisPositive[axis]}");
                    playerPosition.x -= 10f;
                    axisFirstDown[axisPositive[axis]] = false;
                    axisFirstUp[axisPositive[axis]] = false;
                    StartCoroutine(DoubleTapDelayTimer());
                }
                else if (!axisFirstUp[axisPositive[axis]] && axisFirstDown[axisPositive[axis]] && Input.GetAxisRaw(axisName[axis]) == 0)
                {
                    Debug.Log($"firstUp {axisPositive[axis]}!");
                    axisFirstUp[axisPositive[axis]] = true;
                    StartCoroutine(KeyUpTimer(axis));
                }
                else if (!doubleTapped && !axisFirstDown[axisPositive[axis]] && !axisPrevDown[axisPositive[axis]] && Input.GetAxisRaw(axisName[axis]) > 0)
                {
                    Debug.Log($"firstDown {axisPositive[axis]}!");
                    axisFirstDown[axisPositive[axis]] = true;
                    StartCoroutine(KeyDownTimer(axis));
                }
                // negative
                else if (axisFirstDown[axisNegative[axis]] && Input.GetAxisRaw(axisName[axis]) < 0)
                {
                    Debug.Log($"Double Tap {axisNegative[axis]}");
                    playerPosition.x -= 10f;
                    axisFirstDown[axisNegative[axis]] = false;
                    axisFirstUp[axisNegative[axis]] = false;
                    StartCoroutine(DoubleTapDelayTimer());
                }
                else if (!axisFirstUp[axisNegative[axis]] && axisFirstDown[axisNegative[axis]] && Input.GetAxisRaw(axisName[axis]) == 0)
                {
                    Debug.Log($"firstUp {axisNegative[axis]}!");
                    axisFirstUp[axisNegative[axis]] = true;
                    StartCoroutine(KeyUpTimer(axis));
                }
                else if (!doubleTapped && !axisFirstDown[axisNegative[axis]] && !axisPrevDown[axisNegative[axis]] && Input.GetAxisRaw(axisName[axis]) < 0)
                {
                    Debug.Log($"firstDown {axisNegative[axis]}!");
                    axisFirstDown[axisNegative[axis]] = true;
                    StartCoroutine(KeyDownTimer(axis));
                }
            }
        }
        //Timer which controlls the minimun time between double taps
        private IEnumerator DoubleTapDelayTimer()
        {
            doubleTapped = true;
            yield return new WaitForSeconds(delayBetweenDoubleTaps);
            doubleTapped = false;
        }
        //Timers for the axis
        private IEnumerator KeyDownTimer(AxisDirection axis)
        {
            yield return new WaitForSeconds(maxKeyDownTime);
            axisFirstDown[axis] = false;
        }
        private IEnumerator KeyUpTimer(AxisDirection axis)
        {
            yield return new WaitForSeconds(maxKeyUpTime);
            axisFirstUp[axis] = false;
        }
        //Store the raw input conditions for the horizontal axis as reference in next frame
        private IEnumerator KeyInputBuffer()
        {
            yield return new WaitForEndOfFrame();
            foreach (var axis in (Axis[])Enum.GetValues(typeof(Axis)))
            {
                axisPrevDown[axisPositive[axis]] = false;
                axisPrevDown[axisNegative[axis]] = false;
                if (UnityEngine.Input.GetAxisRaw(axisName[axis]) > 0)
                {
                    axisPrevDown[axisPositive[axis]] = true;
                }
                else if (UnityEngine.Input.GetAxisRaw(axisName[axis]) < 0)
                {
                    axisPrevDown[axisNegative[axis]] = true;
                }
            }
        }
    }
