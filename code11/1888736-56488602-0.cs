    private Renderer playerRenderer;
    void Start() 
    {
        playerRenderer = player.gameObject.GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Renderer collidedRenderer = collision.gameObject.GetComponent<Renderer>();
        
        if (collidedRenderer != null && 
                collidedRenderer.material.color == playerRenderer.material.color)
        {
            Debug.Log("saya warna sama");
        }
    }
