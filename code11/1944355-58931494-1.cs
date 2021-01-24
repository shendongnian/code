    void OnCollisionEnter(Collider collider )
    {       
        if (collider.gameObject.tag == "BlueLaunchpad")
        {
            Physics.IgnoreCollision(collider); 
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
