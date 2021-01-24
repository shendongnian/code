using System;
using Newtonsoft.Json;
using Xamarin.Essentials;
namespace YourNamespace
{
    static class Preferences
    {
        public static List<string> SavedList
        {
            get
            {
                var savedList = Deserialize(Preferences.Get(nameof(SavedList), string.empty));
                return savedList ?? new List<string>();
            }
            set
            {
                var serializedList = Serialize(value);
                Preferences.Set(nameof(SavedList), serializedList);
            }
        }
        static T Deserialize<T>(string serializedObject) => JsonConvert.DeserializeObject<T>(serializedObject);
        static string Serialize<T>(T objectToSerialize) => JsonConvert.SerializeObject(objectToSerialize);
    }
}
3. Reference `Preferences.SavedList` from anywhere in your code
void AddToList(string text)
{
    var savedList = Preferences.SavedList;
    savedList.Add(text);
    Preferences.SavedList = savedList;
}
