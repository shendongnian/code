    delegate void OnSpawn(GameObject gameObject); //Create delegate type
    public OnSpawn onSpawn; //Create variable from delegate type
    
    void SetUpStats(Gameobject gameObject){
        //Set hp, initialize spells
    }
    
    void SetUpAnimations(GameObject gameObject){
        //Initialize animations
    }
    
    void PlaySpawnSound(GameObject gameObject){
        //Play a spawn sound
    }
    
    void Start(){
        if (onSpawn == null) //Add content to delegate
        {
            onSpawn = new OnSpawn(SetUpStats); //You may be able to write onSpawn = SetUpStats; instead, for shorter code. But please test it.
            onSpawn += SetUpAnimations;
            onSpawn += PlaySpawnSound;
        }
    }
    void Spawn(){
        onSpawn(gameObject); 
        //Call delegate, invoking all methods stored in it. 
        //Note that they all receive the same input. In this case the gameObject.
        //You can give them any input you want, so long as you define it in the delegate type.
        //I chose a gameObject as you can get all components and more from it.
    }
