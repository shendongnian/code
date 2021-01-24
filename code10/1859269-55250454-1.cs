    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            AmmoSound.Play();
    
            if (Ammo_count.LoadedAmmo == 0)
            {
                Ammo_count.LoadedAmmo += 10;
                this.gameObject.SetActive(false);
            }
            else
            {
                Ammo_count.CurrentAmmo += 10;
                this.gameObject.SetActive(false);
            }
        }
    }
