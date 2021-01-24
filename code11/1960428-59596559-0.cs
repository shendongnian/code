using UnityEngine;
public class HealthScript: MonoBehaviour
{
    public int healthPoints = 100;
    public int damage = 5;
    public bool OnDamagingObject = false;
    void Update()
    {
        if (OnDamagingObject)
        {
            healthPoints -= damage;
        }
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        GameObject collider = hitInfo.gameObject;
		if (collider.tag == "DamagingObject") {
			OnDamagingObject = True;
		}
	}
    void OnTriggerExit2D (Collider2D hitInfo)
    {
        GameObject collider = hitInfo.gameObject;
		if (collider.tag == "DamagingObject") {
			OnDamagingObject = false;
		}
	}
}
