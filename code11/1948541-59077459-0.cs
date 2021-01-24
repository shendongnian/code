public class LookAtMouse : MonoBehaviour
{
    //The object to rotate with/look at the mouse
    public Transform target;
    //Update is called once per frame
    public void Update()
    {
        //Get mouse position in 3D space
        Plane target = new Plane(Vector3.up, 0);
        Ray r = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
        //On the hit, rotate the target to the "impact point"
        if(target.Raycast(r, out float distance)
            Vector3 hitPoint = r.GetPoint(distance);
    }
}
