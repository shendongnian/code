csharp
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
[DisallowMultipleComponent]
internal sealed class XMLManager : MonoBehaviour
{
    public ItemDatabase ItemDatabase = new ItemDatabase();
    public void SaveItem()
    {
        var xmlSerializer = new XmlSerializer(typeof(ItemDatabase));
        var fileStream = new FileStream(Application.dataPath + "/StreamingFiles/XML/Items.xml", FileMode.Create);
        xmlSerializer.Serialize(fileStream, ItemDatabase);
        fileStream.Close();
    }
    public void LoadItem()
    {
        var xmlSerializer = new XmlSerializer(typeof(ItemDatabase));
        var fileStream = new FileStream(Application.dataPath + "/StreamingFiles/XML/Items.xml", FileMode.Open);
        ItemDatabase = xmlSerializer.Deserialize(fileStream) as ItemDatabase;
        fileStream.Close();
    }
}
[System.Serializable]
public sealed class Item
{
    public string Name;
    public string Description;
    public int Damage;
    public Source Element;
    public enum Source { Fire, Water, Air };
}
[System.Serializable]
public sealed class ItemDatabase
{
    public List<Item> items = new List<Item>();
}
This is the code that works for me.
Hope this will help someone out there.
Thanks.
