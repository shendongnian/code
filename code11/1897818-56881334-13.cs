    public class LoadFirstscene : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            MySceneManager.LoadScene(1, this);
        }
    }
