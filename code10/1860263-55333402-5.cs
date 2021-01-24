    IEnumerator FetchMovies(string movieName)
    {
        WWW www = new WWW(url+"search/movie?api_key="+apiKey+"&query="+movieName);
        yield return www;
        if(www.error==null)
        {
            var movies = Newtonsoft.Json.JsonConvert.DeserializeObject<Movies>(www.text);
            foreach(var movie in movies.results)
            {
                Debug.Log("Title " + movie.title);
                Debug.Log("Overview " + movie.overview);
            }
        }
        else
        {
            Debug.LogError(www.error);
        }
    }
