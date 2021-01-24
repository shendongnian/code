    public Game Clone(Game other)
    {
        return JsonConvert.DeserializeObject<Game>(JsonConvert.SerializeObject(other));
    }
What this does is creates a new copy of the original object and changing anything within this new object will not affect the orginal list or game object you had.
You can use the above method like this,
Game g1 = new Game().Clone(Matrix[0]);
