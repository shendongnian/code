public class YourScript : MonoBehaviour
{
    //Remember to attach your Button in the Inspector
    public Button mybutton;
    private bool toggle = false;
    void Start()
    {
        mybutton.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        toggle = !toggle;
    }
    void Update()
    {
        if(toggle)
        {
            // do your stuff that you want to do here!
        }
    }
}
The code in `Start()` is telling the button to perform the `OnClick()` function every time it is pressed, and then in `Update()` you are only executing your code when `toggle` is true.
