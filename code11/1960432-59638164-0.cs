using UnityEngine;
public class DamageScript : MonoBehaviour
{
    public HealthScript healthScript;
    public float damage = 5f;
    void OnTriggerStay2D(Collider2D hitInfo)
    {
        GameObject other = hitInfo.gameObject;
        if (other.CompareTag("Player"))
        {
            healthScript.healthPoints -= damage;
        }
    }
}
