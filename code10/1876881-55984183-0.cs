    public void Shake()
    {
        //picking the index of the answer to show the user
        Random r = new Random();
        _currentIndex = r.Next(_answers.Count);
    }
    public string GetAnswer()
    {
        //using the index picked by shake to return the answer
        return _answers[_currentIndex];
    }
