    public class Tomato
    {
        private readonly ITomatoWebRequester _webRequester;
        public Tomato(string uniqueID, ITomatoWebRequester webRequester)
        {
            _webRequester = webRequester;
        }
    
        public Movie FindMovieById(int movieID)
        {
            var responseJSON = _webRequester.GetMovieJSONByID(movieID);
            //The next line is what we want to unit test
            return Movie.Parse(responseJSON); 
        }
    }
    
    public interface ITomatoWebRequester
    {
        string GetMovieJSONByID(int movieID);
    }
