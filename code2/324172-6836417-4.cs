    // parameters and return type must match!
    public void Move(Actor actor, MoveDirection moveDir)
    {
        ProcessMove (moveDir);
    }
    public static void MoveStatic(Actor actor, MoveDirection moveDir)
    {
        ProcessMove (moveDir);
    }
