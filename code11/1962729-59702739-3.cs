    private Dictionary<PortalSide, Transform> portalSpawns;
    private Dictionary<PortalSide, Collider> portalColliders;
    private void Awake()
    {
        portalSpawns = new Dictionary<PortalSide, Transform> { {PortalSide.blue, bluePortalSpawnPoint} , {PortalSide.orange, orangePortalSpawnPoint}};
        portalColliders = new Dictionary<PortalSide, Collider> { {PortalSide.blue, bluePortalCollider}, {PortalSide.orange, orangePortalCollider} };
    }
    public void CreateClone(PortalSide whereToCreate)
    {
        var spawnPoint = PortalSides[whereToCreate];
        
        var instantiatedClone = Instantiate(clone, spawnPoint.position, Quaternion.identity);
        instantiatedClone.gameObject.name = "clone";
    }
    public void DisableCollider(PortalSide ColliderToDisable)
    {
        var colliderToDisable = portalColliders[ColliderToDisable];
        colliderToDisable.enabled = false;
    }
