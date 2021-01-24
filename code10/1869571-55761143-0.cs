json
{
  "Items": [
    {
      "id": "1",
      "text": "7:15 A.M. School starts at 8:05",
      "choices": "",
      "consequences": "2"
    },
    {
      "id": "2",
      "text": "What do you want to do?",
      "choices": "1: Sleep for a while; 2: Get up",
      "consequences": "3?5"
    }
  ]
}
DialogueManager.cs:
c#
using System.IO;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }
    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
public class DialogueManager : MonoBehaviour
{
    [Serializable]
    public class Dialogue
    {
        public int id;
        public string text;
        public string choices;
        public string consequences;
        public Dialogue(int id, string text, string choices, string consequences)
        {
            this.id = id;
            this.text = text;
            this.choices = choices;
            this.consequences = consequences;
        }
    }
    Dialogue[] dial;
    public static DialogueManager instance = null;
    string[] splits;
    int[] consequences;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            enabled = false;
        }
        StreamReader sR = new StreamReader(Application.dataPath + "/GameData/dialogues.json");
        //NON CRITTOGRAFIA
        string json = sR.ReadToEnd();
        //CRITTOGRAFIA
        //string crypted = sR.ReadToEnd();
        //string json = Encrypt.DecryptString(crypted, "think");
        dial = JsonHelper.FromJson<Dialogue>(json);
    }
    public string GetText(int currentText)
    {
        return dial[currentText - 1].text;
    }
    public string GetTextChoices(int textNum)
    {
        return dial[textNum - 1].choices;
    }
    public int[] GetChoicesConsequences(int textNum)
    {
        string output = dial[textNum - 1].consequences;
        splits = output.Split('?');
        consequences = new int[splits.Length];
        for (int i = 0; i < splits.Length; i++)
        {
            consequences[i] = int.Parse(splits[i]);
        }
        return consequences;
    }
}
