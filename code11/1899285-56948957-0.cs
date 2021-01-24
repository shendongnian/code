csharp
public class RandomNumber : MonoBehaviour
{
    private List<int> _validNumbers;
    public int number;
    private void Awake()
    {
        for (int i = 0; i < 10; i++)        {
            _validNumbers.Add(i+1);
            
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_validNumbers.Count == 0) Debug.Log("No valid Numbers");
            else
            {
                var nextIndex = Random.Range(0, _validNumbers.Count - 1);
                number = _validNumbers[nextIndex];
                _validNumbers.RemoveAt(nextIndex);
            }
        }
    }
}
