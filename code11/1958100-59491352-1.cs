    if (qrCodeObj["Active"] == true && qrCodeObj["Completed"] == false)
    {
       var matchingLink = new WebClient().DownloadString(qrCodeString);
       var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject (matchingLink);
       var candidateId = obj.First.First["CandiateID"].ToString();
       string page = $"https://*********.firebaseio.com/Candidates/.json?orderBy=\"$key\"&startAt=\"{candidateId}\"&limitToFirst=1";
       using (HttpClient client = new HttpClient())
       using (HttpResponseMessage response = await client.GetAsync(page))
       using (HttpContent content = response.Content)
       {
         // Reading the string. 
         Dictionary<string, Candidates> evaluationDictionary = new Dictionary<string, Candidates>();
         string result = await content.ReadAsStringAsync();
         evaluationDictionary = JsonConvert.DeserializeObject<Dictionary<string, Candidates>>(result);
         Debug.Log(evaluationDictionary);
         foreach (Candidates candidates in evaluationDictionary.Values)
           {
            string evaluationMessage = candidates.FirstName + " " + candidates.LastName;
            candidateMessage = GetComponent<Text>();
            candidateMessage.text = evaluationMessage;
           }
           // Getting a reference to the text component.
           candidateMessage = GetComponent<Text>();
           candidateMessage.text = matchingLink.ToString();
           candidateMessage.text = matchingLink.Trim(new char[] {'"'});
         }
    }
    else
    {
       EditorUtility.DisplayDialog("Incorrect Credentials ",
                     "Please scan a valid QR code. " , "OK");
    }
