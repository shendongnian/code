    // Adjust in the inspector
    [SerializeField] private float cooldownTime = 3;
    // Already reference this via the Inspector if possible
    [SerializeField] private Button button;
    private void Awake ()
    {
        // Do this only once!
        if(!button) button = GetComponemt<Button>();
    }
    public void DisableButton()
    {
        button.interactable = false;
      
        // typo in Animator btw ;)
        myAnimatior.SetTrigger("ButtonCooldownAnimation");
        // Make the Animator play slower so the animation now takes 3 seconds
        myAnimatior.speed = 1/cooldownTime;
        // Instead of Update simply use Invoke here
        // Execute the method called WhenCooldownDone after cooldownTime seconds
        Invoke(nameof(WhenCooldownDone), cooldownTime);
    }
    private void WhenCooldownDone ()
    {
        button.interactable = true;
        myAnimator.speed = 1;
    }
