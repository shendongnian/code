    int dir = 0;
    void CheckDirection()
    {
        if (direction.x > 0)
        {
            dir = 1;
        }
        else if (direction.x < 0)
        {
            dir = 2;
        }
 
        if (direction.y > 0)
        {
            dir = 3;
        }
        else if (direction.y < 0)
        {
            dir = 4;
        }
        else
        {
            dir = 0;
        }
 
    }
.
    void DisableInteractionColliders()
    {
            LeftCollider.SetActive(false);
            RightCollider.SetActive(false);
            TopCollider.SetActive(false);
            BottomCollider.SetActive(false);
            switch(dir)
            {
                case 1: RightCollider.SetActive(true);
                        break;
                case 2: LeftCollider.SetActive(true);
                        break;
                case 3: TopCollider.SetActive(true);
                        break;
                case 4: BottomCollider.SetActive(true);
                        break;
                default: break;
            }
    }
