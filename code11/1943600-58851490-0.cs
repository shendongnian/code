    public virtual void UpdatePosition(Vector3 destination)
    {
        Node node = m_grid.NodeFromWorldPoint(transform.position);
        Vector3 direction = destination - transform.position;
        if(destination.x == transform.position.x || destination.z == transform.position.z)
        {
            //Direction is staying the same
            movementSpeed = 1f;
        }else{
            movementSpeed = 0.5f;
        }
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);
        UnityEngine.Debug.Log("Speed NPC : " + movementSpeed);
    }
