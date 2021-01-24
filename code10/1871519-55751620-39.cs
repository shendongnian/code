    public class A : MonoBehaviour
    {
        [SerializeField] private Transform someObject;
        public Vector3 GetObjectPosition()
        {
            return someObject.position;
        }
    }
