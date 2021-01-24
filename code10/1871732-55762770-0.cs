using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    public string DATA_PATH = "player.json";
    void Start()
    {
        GamePalyer p = new GamePalyer();
        p.Id = 1;
        p.Name="John Smith";
        p.Score = 100;
        Debug.Log("Starts Saving");
        SaveDataToFile(p);
        ReadData();
    }
    public void SaveDataToFile(GamePalyer _player)
    {
        string filePath = Application.persistentDataPath + "/" + DATA_PATH;
        Debug.Log("Saving At : "+ filePath);
        string savedData = JsonUtility.ToJson(_player);
        File.WriteAllText(filePath, savedData);
    }
    public void ReadData()
    {
        string filePath = Application.persistentDataPath + "/" + DATA_PATH;
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath); ;
            GamePalyer player = JsonUtility.FromJson<GamePalyer>(data);
            Debug.Log(player.Id);
            Debug.Log(player.Name);
            Debug.Log(player.Score);
        }
    }
}
[System.Serializable]
public class GamePalyer
{
    public int Id;
    public string Name;
    public float Score;
}
