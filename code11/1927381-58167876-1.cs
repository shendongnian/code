public class PickUpObject : MonoBehaviour {
    public float timer = 10f; //seconds
    private void Update()
    {
        timer -= Time.deltaTime;
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
