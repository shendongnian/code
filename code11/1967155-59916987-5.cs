    [Route("/homeController/returnedAnswers")]
    public List<ReturnedAnswers> Answers(string json)
    {
        List<ReturnedAnswers> returnedAnswers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReturnedAnswers>>(json);
        // here you can do all the logic to manipulate your result...
        // We just sent back to the ajax call the json data and we can check it in the console log
        return returnedAnswers;
    }
