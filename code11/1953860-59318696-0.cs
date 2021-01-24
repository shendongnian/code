csharp
public void Load()
{
    // Open file
    try
    {
       var file = new FileStream(saveFileName, FileMode.Open, FileAccess.Read);
       // Read file.
       state = (SaveState)formatter.Deserialize(file);
       file.Close();
       //After obtaining the SaveState we apply the values to our player's local rotation
       player.transform.localRotation = Quaternion.Euler(state.RotationX, state.RotationY, state.RotationZ);
    }
    catch
    {
       Debug.Log("No save file found, creating a new entry");
       Save();
    }
}
(Note that although i'm assigning the values to the player inside your `Load` method here, I would recommend doing that in a separate method for cleaner code)
