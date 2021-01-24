    public async void PlayAudioFromText(string text)
    {
        string url = "https://texttospeech.googleapis.com/v1/text:synthesize?&key=" + ApiKey;
        ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
        
        try {
            var httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
    
            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                string json = "{ \"input\": { \"text\": \"" + text + "\" }, \"voice\": { \"languageCode\": \"en-gb\", \"name\": \"en-GB-Standard-A\", \"ssmlGender\": \"FEMALE\" }, \"audioConfig\": { \"audioEncoding\": \"MP3\" } }";
                await streamWriter.WriteAsync(json);
                await streamWriter.FlushAsync();
            }
    
            var httpResponse = await httpWebRequest.GetResponseAsync();
    
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = await streamReader.ReadToEndAsync();
                AudioContent audioContent = JsonUtility.FromJson<AudioContent>(result);
                string filePath = SaveMP3FromBase64String(audioContent.audioContent);
                StartCoroutine(PlayAudio(filePath));
            }
        }
        catch (WebException ex)
        {
            var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            Debug.Log(resp);
        }
    }
