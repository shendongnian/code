    public class DamgePlayer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D othercollision)
        {
            int playerdmgAmount = GetComponent<PlayerLivesDisplay>().PlayerdmgAmount;
            ...
        }
    }
