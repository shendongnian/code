[RequireComponent(typeof(CircleCollider2D), typeof(CircleCollider2D))]
public class Planet : MonoBehaviour
{
    [Range(0.1f, 50f)]
    public float gravitation = 0.45f;
    [Range(4, 50)]
    public float gravitationRadius = 11f;
    [Range(0f, 10f)]
    public float rotationSpeed = 0.9f;
    private CircleCollider2D gravitationTrigger;
    void Start()
    {
        gravitationTrigger = GetComponents<CircleCollider2D>()[1];
        gravitationTrigger.isTrigger = true;
        gravitationTrigger.radius = gravitationRadius / transform.localScale.x;
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
        foreach (var objectInVicinity in objectsInRange)
        {
            if (objectInVicinity == null) {
                objectsInRange.Remove(objectInVicinity);
                break;
            }
            float dist = Vector2.Distance(transform.position, objectInVicinity.transform.position);
            float gravitationFactor = 1 - dist / gravitationRadius;
            Vector2 force = (transform.position - objectInVicinity.transform.position).normalized * gravitation * gravitationFactor;
            objectInVicinity.AddForce(force);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gravitationRadius);
    }
    private List<Rigidbody2D> objectsInRange = new List<Rigidbody2D>();
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var rb = collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            objectsInRange.Add(rb);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        var rb = collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            objectsInRange.Remove(rb);
        }
    }
}
Basically, you create objects with a trigger circle collider. When an object hits the collider they will enter the planet's vicinity for applying gravity (you set the force/planet as well). More gravity the closer you are. If you leave, all gravitational forces are removed.
Here's a gif of the code in action; you can see the gravitational pull of the smaller planet:
![](https://static.jam.vg/raw/fca/z/18ffd.gif)
[And link to the game](https://ldjam.com/events/ludum-dare/42/not-enough-space-2)
