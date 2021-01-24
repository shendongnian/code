    void OnCollisionEnter(Collider collider )
    {       
        if (collider.gameObject.tag == "BlueLaunchpad")
        {
            Physics.IgnoreCollision(BlueLaunchpad.collider); 
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
