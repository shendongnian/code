    using UnityEngine;
    using System.Collections;
    using SimpleJSON;
    
    public class LocationFinder: MonoBehaviour
    {
        string jsonData;
    
        // Use this for initialization
        IEnumerator Start()
        {
            Debug.Log("Starting");
            // implememt WWW to get json data from any url 
            //http://ip-api.com/json
            string url = "http://ip-api.com/json";
            WWW www = new WWW(url);
            yield return www;
    
            // store text in www to json string
            if (string.IsNullOrEmpty(www.error))
            {
                jsonData = www.text;
            }
            // use simpleJSON to get values stored in JSON data for different key value pair
            JSONNode jsonNode = SimpleJSON.JSON.Parse(jsonData);
            Debug.Log("Latitude " + jsonNode["lat"].ToString());
            Debug.Log("Longtitude " + jsonNode["lon"].ToString());
        }
    }
