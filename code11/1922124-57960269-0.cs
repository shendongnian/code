    public void DoMove(bool right)
    {
        currentDirection = (right ? 1 : -1) * Vector2.right;
    }
    public void StopMove()
    {
        currentDirection = Vector2.zero;
    }
