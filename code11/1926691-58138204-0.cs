namespace AugReal
{
    public class StartAll : MonoBehaviour
    {
        public GameObject prefab;
        public void OnAppear()
        {
            GameObject spawn = Instantiate(prefab, this.transform);
        }
        public void OnDisappear()
        {
            Debug.Log("You lose");
        }
    }
}
