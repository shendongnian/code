    using UnityEngine;
    using System.IO;
    public class HighestScoreJson
    {
        /// <summary>
        /// //Returns the path to the highestScoreFile
        /// </summary>
        /// <returns></returns>
        public static string GetPathToHighestScore() {
            return Path.Combine(Application.persistentDataPath, "HighestScore.json"); //You can look for info about the unity streamingAssets folder in the unity documentation
        }
    
        /// <summary>
        /// Get the highestScore
        /// </summary>
        /// <returns></returns>
        public static HighestScore GetHighestScore() {
            string path = GetPathToHighestScore();
    
            if (!File.Exists(path)) //Checks if the file exists
            {
                HighestScore highestScore = new HighestScore();
                string jsonObj = JsonUtility.ToJson(highestScore);
                //Debug.Log("SavedJsonFile: " + jsonObj);
                FileInfo defaultFile = new FileInfo(path);
                defaultFile.Directory.Create(); // If the directory already exists, this method does nothing.
                File.WriteAllText(path, jsonObj);
            }
    
            string file = File.ReadAllText(path);
            HighestScore highestScoreJson = JsonUtility.FromJson<HighestScore>(file);
            //Debug.Log(highestScoreJson.highestScore); //here you can check the value on the debug if you want
            return highestScoreJson;
        }
    
        /// <summary>
        /// Save a new highestScore
        /// </summary>
        /// <param name="highestScore"></param>
        public static void SaveHighestScore(int highestScoreValue) {
        string path = GetPathToHighestScore();
        HighestScore highestScore = new HighestScore();
        highestScore.highestScore = highestScoreValue;
        string jsonObj = JsonUtility.ToJson(highestScore);
        //Debug.Log("SavedJsonFile: " + jsonObj);
        FileInfo file = new FileInfo(path);
        file.Directory.Create(); // If the directory already exists, this method does nothing.
        File.WriteAllText(path, jsonObj);
        }
    }
    
    /// <summary>
    /// This class holds the highestScore
    /// </summary>
    public class HighestScore
    {
        public int highestScore;
        //You can also create a list if you want with the top 10 or something like that
    }
