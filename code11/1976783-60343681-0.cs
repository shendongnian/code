    public class takeDamage : MonoBehaviour
    {     
    private int PlayerHp = 10f;
    private void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.CompareTag( "Enemy")) {
                    PlayerHp -= 1;
                    Debug.Log("Hit, HP: " + PlayerHp);
                   //Add GUI update function here
                }
        
            }
    }
