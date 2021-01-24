public class PickUpObject : MonoBehaviour {
    public float timer = 10f; //seconds
     private void Update
    {
        timer -= Time.deltatime;
    }
    private void Update
    {
        timer -= Time.deltatime;
    }
    void OnCollisionEnter (Collision Col)
    {
        if (Col.gameObject.name== "Player" && timer <= 0f)
        {
            Debug.Log("collision detected");
            Destroy(gameObject);
        }
    }
}
