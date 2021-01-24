    private Renderer playerRenderer;
    void Start() 
    {
        playerRenderer = player.GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Renderer collidedRenderer = collision.gameObject.GetComponent<Renderer>();
        
        if (collidedRenderer != null && 
                collidedRenderer.material.color.Equals(playerRenderer.material.color) )
        {
            Debug.Log("saya warna sama");
        }
    }
