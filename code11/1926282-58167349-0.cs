    public class CamToUI:MonoBehaviour
    	{
    	[System.NonSerialized] public WebCamTexture wct;
    	public Text nameDisplay;
    	
    	private RawImage rawImage;
    	private RectTransform rawImageRT;
    	private AspectRatioFitter rawImageARF;
    	private Material rawImageMaterial;
    	
    	void Awake()
    		{
    		rawImage = GetComponent<RawImage>();
    		rawImageRT = rawImage.GetComponent<RectTransform>();
    		rawImageARF = rawImage.GetComponent<AspectRatioFitter>();
    		}
    	
