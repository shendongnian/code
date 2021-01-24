    public class AnAwesomeBehaviour : MonoBehaviour
    {
        public void DoSomethingAwesome()
        {
            Debug.Log("Are you not entertained!?");
        }
    }
    public class AnEvenMoreAwesomeBehaviour : AnAwesomeBehaviour 
    {
        public void DoSomethingAwesomeButWithParamters(string horse)
        {
            Debug.Log($"Look at my {horse}, my {horse} is amazing!");
        }
    }
