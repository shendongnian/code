    private float spikeDamageAt= 0.0f;
    
    void update() {    
        if(onSpikes && Time.time >= spikeDamageAt) {
            health -= 0.01f;
            spikeDamageAt= Time.time + 1.0f; // for 1 seconds
        }
    }
