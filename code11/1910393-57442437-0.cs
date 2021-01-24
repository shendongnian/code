    private static BulletManager instance;
    private void Awake
    {
      if ( instance == null ) //this creates a Singleton so you can access it directly from everywhere, won't go deep into explaining how it works exactly
		{
			instance = this;
		}
		else
		{
			Destroy (gameObject);
		}
    }
    
    public int machinegunDmg; //set the initial values in the editor
    public int shotgunDmg;
    public int skeletonDmg;
