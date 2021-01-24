public class Question {
    public string Question { get; set; }
    // if you want to send the answer
    public string Answer { get; set; }
    // if you don't want to send the answer
    public int LineNumber { get; set; }
    // text you show in response to their answer. e.g. "Well done! ..."
    public string ResponseText { get; set; }
}
Then you return that class, with the properties set however you need depending on what happened. For example, if they answered correctly, it would look something like:
return new JsonResult(new Question {
    Question = $"Artist: {artist} First letter of song name: {songletter}",
    Answer = answer, //if you want
    LineNumber = randomNumber,
    ResponseText = $"Well done! You guessed correctly that the song name is: {songname}"
});
