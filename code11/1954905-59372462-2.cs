    // Already reference this via the inspector (drag&drop)
    [SerializeField] private WeaponMaster weaponMaster;
    
    // or as fallback get it on runtime
    private void Awake()
    {
        if(!weaponMaster) weaponMaster = GetComponent<WeaponMaster>();
    }
    
    public void Shoot ()
    {  
        if(!isLocalPlayer) return;
        CmdShoot();
    }
    
    [Command]
    private void CmdShoot ()
    {
        RpcShoot();
    }
    
    // Personally in general I would leave any RPC
    // as close to the method calling it
    // as possible for better maintainability
    [ClientRpc]
    private void RpcShoot ()
    {
        weaponMaster.Shoot();
    }
