    //somewhere in your game1 class:
    GameObject gameObject = new GameObjec(Graphics);
    
    
    //then, in and above the constructor of your GameObject:
    GraphicsDeviveManager GM;
    public GameObject(GraphicsDeviceManager gdm)
    {
       GM = gdm;//GM is now available to the rest of the gameObj class.
    }
