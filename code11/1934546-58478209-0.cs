    public LifeTimer LifeTimer;
    void Start() {
        LifeTimer = Camera.main.GetComponent<LifeTimer>();
    }
    // Destroy sprite once player collides into it 
    void OnCollisionEnter2D(Collision2D col){
       if(col.gameObject.name=="Player"){
           Destroy(gameObject);
           LifeTimer.currentTime += 10;
       }
   }
