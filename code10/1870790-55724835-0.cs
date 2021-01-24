    //Check if the bullet is active, then destroy the ball.
    if(other.gameObject.tag == "yerrow" && other.gameObject.activeSelf)
    { 
        if (ballType >= 0 && ballType < 4)
        {
            ...
            Destroy(this.gameObject);
        }
        else if (ballType == 4)
        {
            Destroy(this.gameObject);
        }
        
        //Destroy and deactive the bullet here
        Destroy(other.gameObject);
        other.gameObject.SetActive(false);
    }
