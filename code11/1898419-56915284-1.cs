    public class Character : MonoBehaviour
        {
            private CharacterModel model;
    
            public void Save()
            {
                // I would use Json.net to serrialize the model
                // Note: this is just a simple and non efficient of saving all characters
    // data, don't use it in production
                PlayerPrefs.SetString(model.Name, JsonConvert.SerializeObject(model));
        
            }
    
            public void Load(string characterName)
            {
                model = JsonConvert.DeserializeObject<CharacterModel>(PlayerPrefs.GetString(characterName));
            }
        }
