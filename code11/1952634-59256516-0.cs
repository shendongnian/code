    public void Update()
    {
        if ( ( currentHealth < maxHealth ) && !healing )
        {
            healing = true;
            StartCoroutine(SlowHeal());
       }
    }
    IEnumerator SlowHeal()
    {
        while (currentHealth < maxHealth) 
        {
            yield return new WaitForSeconds(healingFreq);
            currentHealth += healingAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            SetHealthBar(currentHealth);
        }
        healing = false;
    }
