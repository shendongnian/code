using UnityEngine;
public class HealthScript: MonoBehaviour
{
    public float healthPoints = 100f;
    public float damage = 5f;
    public bool OnDamagingObject = false;
    void Update()
    {
        if (OnDamagingObject)
        {
            healthPoints -= damage * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        GameObject collider = hitInfo.gameObject;
		if (collider.tag == "DamagingObject") {
			OnDamagingObject = true;
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
