    public class YourSelectableClass : MonoBehaviour, IPointerClickHandler
    {
        public bool itemSelected;
        public void Deselect()
        {
            itemSelected = false;
        }
        public override void OnPointerClick(PointerEventData pointerEventData)
        {
            // Deselect all others
            // Note that this only deselects currently active and enabled
           // ones. Later you might rather use a manager class and register them all
           // in order to also look for them only once
            foreach(var selectable in FindObjectsOfType<YourSelectableClass>())
            {
                selectable.Deselect();
            }
            itemSelected = true;
        }    
    }
