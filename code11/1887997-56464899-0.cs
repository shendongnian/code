    public class Rotate : MonoBehaviour
    {
        public enum Axistorotate { Back, Down, Forward, Left, Right, Up, Zero };
        public Vector3[] vectorAxises = new Vector3[7];
        public Axistorotate myAxis;
