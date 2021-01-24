    bool CanStand()
    {
        Transform t = GetComponent<Transform>(); // This should probably go in Start()
        RaycastHit2D hit = Physics2D.Raycast(t.position, Vector2.up);
        if (hit.collider != null)
        {
            // Check the distance to make sure the character has clearance, you'll have to change the 1.0f to what makes sense in your situation.
            if (hit.distance >= 1.0f)
            {
                return true;
            }
        }
        return false;    
    }
