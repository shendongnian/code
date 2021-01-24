    public class flashlight : MonoBehaviour
    {
    	public GameObject light;//Assign this is the inspector
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                light.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                light.SetActive(false);
            }
        }
    }
