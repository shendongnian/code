    public class Character : MonoBehaviour
    {
        private CharacterModel model;
        public void Save()
        {
            // I would use Json.net to serrialize the model rather than Unity's JsonConvert
            // Note: this is just a simple and non-efficient way of saving all characters
            // data, don't use PlayerPrefs in production
            PlayerPrefs.SetString(model.Name, JsonConvert.SerializeObject(model));
        }
        public void Load(string characterName)
        {
            model = JsonConvert.DeserializeObject<CharacterModel>(PlayerPrefs.GetString(characterName));
        }
    }
