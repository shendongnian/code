    // Give your IEnumerator a callback parameter
    public IEnumerator GetMovies(string q, Action<JSONArray> OnSuccess = null)
    {
        var uri = "http://www.omdbapi.com/?apikey=__&s=" + q;
        using (var r = UnityWebRequest.Get(uri))
        {
            yield return r.SendWebRequest();
            if (r.isHttpError || r.isNetworkError)
            {
                Debug.Log(r.error);
            }
            else
            {
                var N = JSON.Parse(r.downloadHandler.text);
                var theJsonArray = N["Search"].Values;
                // Now depending on what you actually mean by one-by-one
                // you could e.g. handle only one MoveInfo per frame like
                foreach (var item in theJsonArray)
                {
                    var movieInfo = new MovieSearchInfo();
                    movieInfo.Title = item["title"];
                    movieInfo.Year = item["Year"];
                    movieInfo.imdbID = item["imdbID"];
                    movieInfo.Type = item["Type"];
                
                    // NOW DO SOMETHING WITH IT
  
                    // wait for the next frame to continue
                    yield return null;
                }
            }
        }
    }
    
