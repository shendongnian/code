    private void addVar(GameObject Move, GameObject Cyl)
    {
        // The function parameter is whatever sent to this function
        // It may or may not be null
        Debug.Log(Move);
        if (Move1 == null)
        {
            // The following will always result in null
            // Because of the above if condition
            Move = Move1;
            Cyl = Cyl1;
            Moves.Add(Move);
            Movecyls.Add(Cyl);
            // Debug value will now be null
            Debug.Log(Move);
        }
    
    // Other operations
    }
