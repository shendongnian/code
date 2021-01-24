    public List<GameObject> characters = new List<GameObject>();
    private Quaternion targetRotation = Quaternion.identity;
    
    public void CharacterPosition(int charNum)
    {
        // Get the goal rotation for the character using `LookRotation`:
        Quaternion charGoalRotation = Quaternion.LookRotation(Vector3.up,
                camera.transform.position - transform.position)
        // Determine the world rotation that needs to apply to the character:
        // delta * char_start = char_end -> delta = char_end * inv(char_start)
        Quaternion worldCharDelta = charGoalRotation 
                * Quaternion.Inverse(characters[charNum].transform.rotation);
        // Apply that same world rotation to the globe:
        targetRotation= worldCharDelta * transform.rotation;
        transform.DORotateQuaternion(targetRotation, 1f);
        hitAgainNumber = charNum;
    }
