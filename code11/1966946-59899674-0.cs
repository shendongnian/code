    public enum Axis
    {
        X,
        Y
    }
    public class DoubleTap : MonoBehaviour
    {
        private const float translationSpeedX = 20;
        private const float translationSpeedY = 20;
        private Vector3 playerPosition;
        private float maxKeyDownTime = 0.2f;
        private float maxKeyUpTime = 0.2f;
        private float delayBetweenDoubleTaps = 0.4f;
        private bool doubleTapped = false;
        private Dictionary<Axis, bool> axisFirstDown = new Dictionary<Axis, bool>();
        private Dictionary<Axis, bool> axisFirstUp = new Dictionary<Axis, bool>();
        private Dictionary<Axis, bool> axisPrevDown = new Dictionary<Axis, bool>();
        private Dictionary<Axis, string> axisName = new Dictionary<Axis, string>
        {
            {Axis.X, "Horizontal"},
            {Axis.Y, "Vertical"}
        };
        // Start is called before the first frame update
        private void Start()
        {
            // setup dictionaries
            foreach (var axis in (Axis[])Enum.GetValues(typeof(Axis)))
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
                //Double tap left
                if (axisFirstDown[axis] && Input.GetAxisRaw(axisName[axis]) < 0)
                {
                    Debug.Log($"Double Tap {axis}");
                    playerPosition.x -= 10f;
                    axisFirstDown[axis] = false;
                    axisFirstUp[axis] = false;
                    StartCoroutine(DoubleTapDelayTimer());
                }
                else if (!axisFirstUp[axis] && axisFirstDown[axis] && Input.GetAxisRaw(axisName[axis]) == 0)
                {
                    Debug.Log($"firstUp {axis}!");
                    axisFirstUp[axis] = true;
                    StartCoroutine(KeyUpTimer(axis));
                }
                else if (!doubleTapped && !axisFirstDown[axis] && !axisPrevDown[axis] && Input.GetAxisRaw(axisName[axis]) < 0)
                {
                    Debug.Log($"firstDown {axis}!");
                    axisFirstDown[axis] = true;
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
        private IEnumerator KeyDownTimer(Axis axis)
        {
            yield return new WaitForSeconds(maxKeyDownTime);
            axisFirstDown[axis] = false;
        }
        private IEnumerator KeyUpTimer(Axis axis)
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
                axisPrevDown[axis] = false;
                if (UnityEngine.Input.GetAxisRaw(axisName[axis]) > 0)
                {
                    axisPrevDown[axis] = true;
                }
            }
        }
    }
