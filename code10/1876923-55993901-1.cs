    //removed touchedCollision from here
    void OnTriggerEnter (Collider other)
    {
        Debug.Log("In Triger");
        other.GetComponent<TestClass>().touchedCollision = true;
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Out Triger");
        other.GetComponent<TestClass>().touchedCollision = false;
    }
