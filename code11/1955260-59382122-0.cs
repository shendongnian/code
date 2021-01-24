c#
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveSystem
{
    // This is a way to make sure your path is the same, and not about to get overwritten
    public static string Path => Application.persistentDataPath + "/player.fun";
    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
        // It's helpful to print out where this is going
        Debug.Log($"Wrote to {Path}");
    }
    public static PlayerData LoadPlayer ()
    {
        if (File.Exists(Path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            // It's also helpful to print out that it worked, not just log errors if it fails
            Debug.Log($"Successfully read from {Path}");
            return data;
        }
        else
        {
            Debug.LogError("Save file not in " + Path);
            return null;
        }
    }
}
  [1]: https://stackoverflow.com/users/687262/bugfinder
