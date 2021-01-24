public class RandomNumber : MonoBehaviour
{
    private Shuffler _shuffler;
    public int number;
    private void Awake()
    {
        _shuffler = new Shuffler(10)
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
			if(!_shuffler.TryGetNext(out number))
			{
				Debug.Log("No valid Numbers");
			}
        }
    }
}
