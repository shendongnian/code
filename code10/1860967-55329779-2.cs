        if(facingRight)
        {
            RightCollider.SetActive(true);
            LeftCollider.SetActive(false);
            TopCollider.SetActive(false);
            BottomCollider.SetActive(false);
        } 
        else if(!facingRight)
        {
            LeftCollider.SetActive(true);
            RightCollider.SetActive(false);
            TopCollider.SetActive(false);
            BottomCollider.SetActive(false);
        }
 
        else if(facingUp)
        {
            TopCollider.SetActive(true);
            RightCollider.SetActive(false);
            LeftCollider.SetActive(false);
            BottomCollider.SetActive(false);
        } 
        else if(!facingUp)
        {
            BottomCollider.SetActive(true);
            RightCollider.SetActive(false);
            LeftCollider.SetActive(false);
            TopCollider.SetActive(false);
        }
