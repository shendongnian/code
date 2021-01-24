    public class Example : MonoBehaviour
    {
        public Vector3 myTarget;
        private void Start()
        {
            StartCoroutine(MoveTo());
        }
    
        private IEnumerator MoveTo()
        {
            while (transform.position != myTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, myTarget, Time.deltaTime * 2f);
                yield return null;
            }
        Debug.Log("We reached Target. Done!");
        yield return null;
        }
    }
