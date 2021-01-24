    private Renderer playerRenderer;
    void Start() 
    {
        playerRenderer = player.GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Renderer collidedRenderer = collision.gameObject.GetComponent<Renderer>();
        
        if (collidedRenderer != null && 
                (Vector4)collidedRenderer.material.color ==
                (Vector4)playerRenderer.material.color
                )
        {
            Debug.Log("saya warna sama");
        }
    }
