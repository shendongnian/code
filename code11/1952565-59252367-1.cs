    public class Example : MonoBehaviour
    {
        Toggle m_Toggle;
        void Start()
        {
            //Fetch the Toggle GameObject
            m_Toggle = GetComponent<Toggle>();
            //Add listener for when the state of the Toggle changes, to take action
            m_Toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(m_Toggle);
            });
        }
        //Output the new state of the Toggle into Text
        void ToggleValueChanged(Toggle change)
        {
            //Activate your game object
        }
    }
