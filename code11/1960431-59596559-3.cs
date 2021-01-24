using System.Collections;
using UnityEngine;
public class HealthScript : MonoBehaviour
{
    public float healthPoints = 100f;
    public float damage = 5f;
    public bool OnDamagingObject = false;
    IEnumerator DealDamage()
    {
        while (OnDamagingObject)
        {
            healthPoints -= damage;
            yield return new WaitForSeconds(1f);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        GameObject collider = hitInfo.gameObject;
        if (collider.tag == "DamagingObject")
        {
            OnDamagingObject = true;
            StartCoroutine(DealDamage());
        }
    }
    void OnTriggerExit2D(Collider2D hitInfo)
    {
        GameObject collider = hitInfo.gameObject;
        if (collider.tag == "DamagingObject")
        {
            OnDamagingObject = false;
        }
    }
}
