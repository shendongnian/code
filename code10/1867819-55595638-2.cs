    public class test2 : MonoBehaviour
    {
    	private Color[] colors = { new Color(0, 1, 0, 1), new Color(1, 0, 0, 1), new Color(1, 1, 1, 1), new Color(0, 0, 1, 1), new Color(1, 1, 0, 1), new Color(0, 0, 0, 1) };
    
    	public Color winColor
    	{
    		get; set;
    	}
    
    	// Start is called before the first frame update
    	void Start()
        {
    		winColor = colors[1];
    		Debug.Log("con wincolor:" + winColor);
    	}
    
    }
