    void ClickMove()
    {
        if (MoveController)
        {
            characterController.SimpleMove(offsetVec * Time.deltaTime * speed);
            MoveController = false;
        }    
    }
