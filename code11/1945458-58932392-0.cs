    public virtual void UpdatePosition(Vector3 destination) {
        Node node = m_grid.NodeFromWorldPoint(transform.position);
    
        Vector3 direction = destination - transform.position; //destination is path found from pathfinding
        Vector3 posNPC = transform.position - new Vector3(0.1f, 0.0f, 0.1f);
    
        //get position x and z of npc and path found
        //in this statment, if x or z of npc and path is same so npc will increase speed, if not npc will decrease speed
        if (Math.Round(posNPC.z, 1) == Math.Round(destination.z, 1) || Math.Round(posNPC.x, 1) == Math.Round(destination.x, 1)) {
    
            movementSpeed = 2f;
            print("TRUE");
        } else if (Math.Round(posNPC.z != Math.Round(destination.z, 1) || Math.Round(posNPC.x, 1) != Math.Round(destination.x, 1))) {
            movementSpeed = 1f;
            print("FALSE");
        }
    
        //Position NPC
        UnityEngine.Debug.Log("Position NPC in koordinat Z : " + posNPC.z.ToString("f1"));
        UnityEngine.Debug.Log("Position NPC in koordinat X : " + transform.position.x.ToString("f1"));
        //Position PATH
        UnityEngine.Debug.Log("Position PATH  in koordinat Z : " + destination.z.ToString("f1"));
        UnityEngine.Debug.Log("Position PATH in koordinat X : " + destination.x.ToString("f1"));
    
        //move
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);
        UnityEngine.Debug.Log("Speed NPC : " + movementSpeed);
    
    }
