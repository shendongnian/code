    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Hand")
        {
            counter = Player.GetComponent<PlayerController>().jumpCounter;
            LevelFinishedPanel.SetActive(true);
            Player.GetComponent<Rigidbody2D>().constraints = 
    RigidbodyConstraints2D.FreezeAll;
            if(counter <= maxJumpsForGold)
            {
                ShowUpJumpCounter.text = "Jumps you needed: " + counter.ToString();
                Gold.enabled = true;
            }
            else if (counter <= maxJumpsForSilver && counter > maxJumpsForGold)
            {
                ShowUpJumpCounter.text = "Jumps you needed: " + counter.ToString();
                Silver.enabled = true;
            }
            else if (counter <= maxJumpsForBronze && counter> maxJumpsForSilver)
            {
                ShowUpJumpCounter.text = "Jumps you needed: " + counter.ToString();
                Bronze.enabled = true;
            }
            else
            {
                ShowUpJumpCounter.text = "Jumps you needed: " + counter.ToString();
            }
        }
    }
