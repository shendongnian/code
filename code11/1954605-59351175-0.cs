c#
public class PistolPickup : MonoBehaviour
{
    void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed the pickup.");
        }
    }
}
NOTE: for the code to work you have to check **IsTrigger** option on the pickup objects collider.
