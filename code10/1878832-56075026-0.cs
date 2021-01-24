    [System.Serializable]
    public class Level
    {
        public int Score;
        // ...
    }
    
    [System.Serializable]
    public class City
    {
        public List<Level> Levels = new List<Level>();
    }
    
    [System.Serializable]
    public class Country
    {
        public List<City> Cities = new List<City>();
    
        public City this[int cityIndex]
        {
            get
            {
                if (cityIndex < 0 || cityIndex >= Cities.Count)
                {
                    return null;
                }
                else
                {
                    return Cities[cityIndex];
                }
            }
        }
    }
    
    [System.Serializable]
    public class LevelData
    {
        public List<Country> Countries = new List<Country>();
    
        public List<Level> this[int countryIndex, int cityIndex]
        {
            get
            {
                if (countryIndex < 0 || countryIndex >= Countries.Count)
                {
                    return null;
                }
                else
                {
                    City city = Countries[countryIndex][cityIndex];
                    if (city != null)
                    {
                        return city.Levels;
                    }
                    else
                    {
                        return null;
                    }
                }
    
            }
        }
    
        public void Save(string path)
        {
            string json = JsonUtility.ToJson(this);
            // Note: add IO exception handling here!
            System.IO.File.WriteAllText(path, json);
        }
    
        public static LevelData Load(string path)
        {
            // Note: add check that the path exists, and also a try/catch for parse errors
            LevelData data = JsonUtility.FromJson<LevelData>(path);
    
            if (data != null)
            {
                return data;
            }
            else
            {
                return new LevelData();
            }
        }
    }
