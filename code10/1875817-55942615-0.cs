public class HoverOverObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    [SerializeField] GameObject uIModalWindow;
    private void Start()
    { 
        uIModalWindow.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData e)
    {
        var mousePos = Input.mousePosition;
        Debug.Log(gameObject.name);
        uIModalWindow.transform.position = mousePos;
        uIModalWindow.SetActive(true);
    }
    public void OnPointerExit(PointerEventData e)
    {
        uIModalWindow.AddComponent<ModalWindowScript>();
    }
}
Note changed code: Added Interfaces, Changed name of methods, Changed accessibility from private to public on methods.
