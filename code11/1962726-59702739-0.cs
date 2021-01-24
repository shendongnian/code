    private void OnTriggerExit2D(Collider2D collision)
    {
        exitVelocity = enteredRigidbody.velocity.x;
        if (enterVelocity != exitVelocity)
        {
            Destroy(GameObject.Find("Clone"));
        }
        Destroy(collision.gameObject);
        PortalControl.portalControlInstance.EnableColliders();
        var clone = GameObject.Find("Clone");
        clone.name = "Character";
        DontDestroyOnLoad(clone);
        // It would ofcourse be way more efficient 
        // if you would store this reference somewhere
        FindObjectOfType<CameraFollow>().target = clone;
    }
