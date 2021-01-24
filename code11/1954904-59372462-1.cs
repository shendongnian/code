    public void Shoot()
    {
        if (ammo == 0) return;
        
        if (isAutomatic)
        {
            keepFiring = true;
            StartCoroutine(Fire());
        }
        else if (!isAutomatic && noQuickFire)
            StartCoroutine(Fire());
    }
