public class Player : MonoBehavior
{
    public delegate void PlayerDiedDelegate();
	public static event PlayerDiedDelegate onPlayerDied;
	private int _health;
	public int health
	{
		get
		{
			return _health;
		}
		set
		{
			_health = value;
			if(_health < 0)
			{
				onPlayerDied?.Invoke();
			}
		}
	}
}
Now you can attach any controller in your scene to the event: <br>
public class ScoreController : MonoBehavior
{
    private void Awake()
    {
        Player.onPlayerDied += OnPlayerDied;
    }
    private void OnPlayerDied()
    {
        // Put your logic here: stop collecting score etc.
    }
}
