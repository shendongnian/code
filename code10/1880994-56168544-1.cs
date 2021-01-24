    public class CharacterList
        {
            List<Character> characterList = new List<Character>();
    
            void PopulateList()
            {
                string[] assetNames = AssetDatabase.FindAssets("Your_Filter", new[] { "Assets/YourFolder" });
                characterList.Clear();
                foreach (string SOName in assetNames)
                {
                    var SOpath    = AssetDatabase.GUIDToAssetPath(SOName);
                    var character = AssetDatabase.LoadAssetAtPath<Character>(SOpath);
                    characterList.Add(character);
                }
            }
        }
