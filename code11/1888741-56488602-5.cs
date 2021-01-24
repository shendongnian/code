    private Renderer playerRenderer;
    private float closeColorSquareDistance = 0.01f;
    void Start() 
    {
        playerRenderer = player.GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Renderer collidedRenderer = collision.gameObject.GetComponent<Renderer>();
        
        if (collidedRenderer != null && 
                (   (Vector4)collidedRenderer.material.color
                  - (Vector4)playerRenderer.material.color
                ).sqrMagnitude < closeColorSquareDistance
                )
        {
            Debug.Log("saya warna sama");
        }
    }
