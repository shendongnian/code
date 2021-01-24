    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "deathcube")
            {
                Debug.Log("collision detected");
                Instantiate(death_explosion_Prefab, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
