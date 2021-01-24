    // reference this already via the Inspector if possible
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float cooldownTime = 1;
    [SerializeField] private float maxEnabledTime = 1;
    // Otherwise get it only ONCE on runtime
    private void Awake()
    {
        if(!_meshRenderer) _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");
        // stop the timeout
        StopAllCoroutines();
        // disable sword and start cooldown
        StartCoroutine(SwordCooldown());
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if(IsSwordActivated) return;
        if (!canSwordGetActivated) return;
        
        Debug.Log("Trigger is down");
        // start timeout
        StartCoroutine(SwordEnabledTimer());
    }
    
    ///<summary>
    /// Disables sword and Runs cooldown before sword can be enabled again
    ///<summary>
    private IEnumerator SwordCooldown()
    {
        canSwordGetActivated = false;
        IsSwordActivated = false;
        _meshRenderer.material = defaultSword;
        
        yield return new WaitForSeconds(cooldownTime);
        canSwordGetActivated = true;
    }
    
    ///<summary>
    /// Disables the sword and jumps to cooldown after it was enabled for too long
    ///<summary>
    private IEnumerator SwordEnabledTimer()
    {
        canSwordGetActivated = false;
        yield return new WaitForSeconds(maxEnabledTime);
        StartCoroutine(SwordCooldown());
    }
