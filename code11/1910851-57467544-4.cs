    void Awake(){
         ClockCollision.onSpeedChangeDelegate += UpdateSpeed;
    }
    //Don't forget to unsubscribe:
    void OnDestroy(){
        ClockCollision.onSpeedChangeDelegate -= UpdateSpeed;
    }
    
    // Update the speed
    void UpdateSpeed(moveSpeed)
    {
            if(ScoreScript.scoreValue > 4)
            {
                directionToTarget = (target.transform.position - transform.position).normalized;
                rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
                                        directionToTarget.y * moveSpeed);
            }
            else
            {
                directionToTarget = new Vector3(0, -1, 0);
                rb.velocity = new Vector2(0, directionToTarget.y * moveSpeed);
            }
    }
    
