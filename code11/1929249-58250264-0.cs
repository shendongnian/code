public class SwitchController : MonoBehaviour {
    // ...
    public GameObject targetPlatform;
    private void OnTriggerStay2D(Collider2D col) {
        // ...
        Destroy(targetPlatform); // Destroy the platform.
    }
}
**Or, you can raycast upwards from the player**
public class SwitchController : MonoBehaviour {
    public Collider2D switchCollider;
    public Rigidbody2D player;
    [SerializeField, Tooltip("The layer mask of the platforms.")]
    public LayerMask platformLayerMask;
    void Start() {
        switchCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D col) {
        var actionBtn = PlayerController.action;
        if (player) {
            if (Input.GetKeyDown(KeyCode.E)) {
                actionBtn = true;
                // Raycast upwards from the player's location.
                // (Raycast will ignore everything but those with the same layermask as 'platformPlayerMask')
                RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.up, Mathf.Infinity, platformLayerMask);
                if (hit.collider != null) {
                    // Destroy what it hits.
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
Compared to the first solution, this solution is more dynamic.<Br>
You just have to set the [Layers](https://docs.unity3d.com/Manual/Layers.html) of the platforms in the inspector.
