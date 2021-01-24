public class HideUnhideBtn : MonoBehaviour
{
    public Button buttonToHide;
    public float comeInTime = 32.5f;
	
	void Start()
    {
        StartCoroutine(HideAndShowButton());
    }
    IEnumerator HideAndShowButton()
    {
        buttonToHide.gameObject.SetActive(false);
        yield return new WaitForSeconds(comeInTime);
        buttonToHide.gameObject.SetActive(true);
    }
}
Here the offical documentation: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
Enjoy!
