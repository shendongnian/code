    public List<GameObject> characters = new List<GameObject>();
    private Quaternion targetRotation = Quaternion.identity;
    
    public void CharacterPosition(int charNum)
    {
        Transform charTransform = characters[charNum].transform;
       
        // Use cross products to find the closest vector to Vector3.up which is orthogonal
        // to the direction from the sphere to the camera. 
        // This direction is to be the sprite's forward after we rotate the sphere
        Vector3 charGoalUp = camera.transform.position - transform.position;
        Vector3 charGoalRight = Vector3.Cross(charGoalUp, Vector3.up);
        Vector3 charGoalForward = Vector3.Cross(charGoalRight, charGoalUp);
   
        // Get the goal rotation for the character using `LookRotation`:
        Quaternion charGoalRotation = Quaternion.LookRotation(charGoalForward, charGoalUp);
        // Determine the world rotation that needs to apply to the character:
        // delta * char_start = char_end -> delta = char_end * inv(char_start)
        Quaternion worldCharDelta = charGoalRotation 
                * Quaternion.Inverse(charTransform.rotation);
        // Apply that same world rotation to the globe:
        targetRotation= worldCharDelta * transform.rotation;
        transform.DORotateQuaternion(targetRotation, 1f);
        hitAgainNumber = charNum;
    }
