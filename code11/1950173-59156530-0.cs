    public class Demo : MonoBehaviour
    {
    
    #pragma warning disable 0649
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
    #pragma warning restore 0649
    
        private void Update()
        {
    		if (Input.GetMouseButtonDown(0))
    		{
    			if (TestClickEvent(Input.mousePosition))
    			{
    				Debug.Log("Clicked UI Element");
    			}
    		}
        }
    
        private bool TestClickEvent(Vector3 mousePos)
        {
            PointerEventData data = new PointerEventData(_eventSystem);
            data.position = mousePos;
    
            List<RaycastResult> results = new List<RaycastResult>();
    
            _graphicRaycaster.Raycast(data, results);
    		if(results.Count > 0)
    		{
    			//You can loop through the results to test for a specific UI element
    			return true;
    		}		
            return false;
        }
    }
