        public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.transform.GetInstanceID() == SnapTarget.GetInstanceID())
        {
            if (lastSnapTime + 0.1f < Time.time)
            {
                snapObj.position = SnapTarget.position;
                snapObj.rotation = SnapTarget.rotation;
                snapObj.parent = SnapTarget;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if (other.transform.GetInstanceID() == SnapTarget.GetInstanceID())
        {
            lastSnapTime = Time.time;
            snapObj.position = transform.position;
            snapObj.rotation = transform.rotation;
            snapObj.parent = transform;
            //StartCoroutine(noSnap);
        }
    }
