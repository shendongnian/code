    private var collisionCount = 0;
     
    void OnCollisionEnter () {
        collisionCount++
    }
     
    void OnCollisionExit () {
        collisionCount--;
    }
    
    void checkForCollision(){
    if(0 == collisionCount) Destroy(gameObject);
    }
