    public class RayDebugger : MonoBehaviour
    {
        private void OnGUI()
        {
            GUI.color = Color.green;
    
            var hovering = EventSystem.current.IsPointerOverGameObject();
    
            var isHovering = hovering ? "Yes" : "No";
    
            GUI.Label(new Rect(100, 100, 200, 200), $"Is hovering something? - {isHovering}");
    
            if (!hovering) return;
    
            var pointer = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
    
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);
    
            if (raycastResults.Count > 0)
            {
                GUI.Label(new Rect(100, 200, 200, 200), $"Currently Hovered: {raycastResults[0]}");
            }
        }
    }
    
