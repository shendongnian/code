    public static readonly string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public static readonly string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };
    public void SetDirection(Vector2 direction)
        {
    
            //use the Run states by default
            string[] directionArray = null;
    
            //measure the magnitude of the input.
            if (direction.magnitude < .01f)
            {
                //if we are basically standing still, we'll use the Static states
                //we won't be able to calculate a direction if the user isn't pressing one, anyway!
                directionArray = staticDirections;
            }
            else
            {
                //we can calculate which direction we are going in
                //use DirectionToIndex to get the index of the slice from the direction vector
                //save the answer to lastDirection
                directionArray = runDirections;
                lastDirection = DirectionToIndex(direction, 8);
            }
    
            //tell the animator to play the requested state
            animator.Play(directionArray[lastDirection]);
        }
