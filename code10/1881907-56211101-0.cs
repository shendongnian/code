    private int brickCount = 0;
    public void AddBrick()
    {
        brickCount++;
    }
    public void RemoveBrick()
    {
        brickCount--;
        // Check if all bricks are destroyed
        if (brickCount == 0)
        {
            LoadLevel("Level1.2");
        }
    }
