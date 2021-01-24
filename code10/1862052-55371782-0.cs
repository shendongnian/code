public class MyBehaviour : MonoBehaviour
{
    private GameObject newGameObject;
    /* other useful code */
    public void OnClick(){
        if (x > 3.14)
        {
            if (newGameObject != null && newGameObject.scene.IsValid())
            {
                Destroy(newGameObject);
                newGameObject = GameObject.Instantiate(object1);
            }
            else
            {
                newGameObject = GameObject.Instantiate(object1);
            }
        }
        else
        {
             Destroy(newGameObject);
        }
    }
}
