    public class Changemat : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.CompareTag("Box"))
            {
                Material tempMat = GetComponent<Renderer>().material;
                GetComponent<Renderer>().material = collision.gameObject.GetComponent<Renderer>().material;
                collision.gameObject.GetComponent<Renderer>().material = tempMat;
            }
        }
    }
