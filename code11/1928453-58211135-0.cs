    public class Test : MonoBehaviour
    {
    
    
        public GameObject[] buttonArray;
    
        private void Start() {
            DisableAllButtonsExcept(1,buttonArray);
        }
    
        private void DisableAllButtonsExcept(int buttonToKeep,GameObject[] arrayToSearch) {
            foreach(GameObject button in arrayToSearch) {
                button.SetActive(false);
            }
            arrayToSearch[buttonToKeep].SetActive(true);
        }
    
    }
