      public void OnTriggerEnter(Collider col)
    {
        Debug.Log("entered");
        if (col.gameObject.name == "RightHandAnchor")
        {
            HandleCollided = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if (other.gameObject.name == "RightHandAnchor")
        {
            print("No longer in contact with " + other.transform.name);
            HandleCollided = false;
        }
    }
