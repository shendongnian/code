public class Fader : MonoBehaiour
{
	// Flag to know if the object is currently being viewed
	public bool IsCurrentlyViewed = false;
	// Time in seconds it takes to fade from 100% brightness to 0% brightness. Default is 3 seconds
	[SerializeField] private float SecondsTimeToFade = 3.0f;
	// Ratio from 0 to 1 to indicate how bright an object should be
	[SerializeField] private float PercentRatioBright = 0.0f;
	// Start and end colors	
	[SerializeField] private Color startingColor;
	[SerializeField] private Color endingColor;
	// Cache the renderer
	private Renderer renderer;
	public void Start()
	{
		renderer = GetComponent<Renderer>();
		startingColor = renderer.material.color;
		if (layer < 8)
			Debug.LogWarning("Fader layer should be set to a player-defined layer");
	}
	public void Update()
	{
		// Fade in when being viewed, fade out when not
		if (PercentRatioBright > 0.0f && PercentRatioBright <= 1.0f)
			Fade();
		
		// Reset the IsCurrentlyViewed bool
		IsCurrentlyViewed = false;
	}
	private void Fade()
	{
		float brightnessRatioUnsignedDifference = Time.deltaTime / SecondsTimeToFade;
		PercentRatioBright += brightnessRatioUnsignedDifference * (IsCurrentlyViewed ? 1 : -1);
		renderer.material.color = Color.Lerp(startingColor, endingColor, PercentRatioBright);
	}
}
##Example call:
public class ThroughTheLookingClass : MonoBehaiour
{
	// Set this so you only hit what you want with the ray
	// Make sure your selectable objects have this layer
	[SerializeField] private LayerMask SelectableLayerMask;
	public Update()
	{
		// Cast screen point to ray, select objects with layermask and have the Fader component
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition, out RaycastHit hit, layerMask: SelectableLayerMask)))
		{
			hit.transform.gameObject.GetComponent<Fader>()?.IsCurrentlyViewed = true;
		}
	}
}
