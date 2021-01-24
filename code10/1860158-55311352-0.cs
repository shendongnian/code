    public void ControlCheck(){
        if (currentTile != null){
            // Rotation code goes here
        }
    }
    void OnCollisionEnter(Collision obj){
        currentTile = obj.transform.gameObject;
    }
