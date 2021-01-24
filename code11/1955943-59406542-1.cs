CS
[Serializable]
public class SaveItems
{
    public ShopItem[] shopitems;
}
So in your SaveGame() you'll get something like this:
CS
public void SaveGame()
{
    // previous code here
    
    BinaryFormatter bf = new BinaryFormatter();
    
    SaveItems si = new SaveItems();
    si.shopitems = shopitems;    
  
    FileStream file = File.Create(Application.persistentDataPath + "/game_save/data/skins_save.txt");
    var json = JsonUtility.ToJson(si);
    bf.Serialize(file, json);
    file.Close();
 
}
