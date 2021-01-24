    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "powerup")
        {
            switch (currentPowerUp)
            {
                case PowerUp.JumpBoost:
                    RemoveJumpBoost();
                    break;
                case PowerUp.SpeedBoost:
                    RemoveSpeedBoost();
                    break;
            }
            do
            {
                //I set the minimum value to 1 to skip "None"
                var nextPowerUp = (PowerUp)UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(PowerUp)).Length);
            }
            while (nextPowerUp == currentPowerUp);
            
            switch (nextPowerUp)
            {
                case PowerUp.JumpBoost:
                    AddJumpBoost();
                    break;
                case PowerUp.SpeedBoost:
                    AddSpeedBoost();
                    break;
            }
            currentPowerUp = nextPowerUp;
        }
    }
