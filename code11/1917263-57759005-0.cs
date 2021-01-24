    public void Vote(Vote vote)
    {
        switch (vote)
        {
            case Vote.DownVote:
                _vote--;
                break;
            case Vote.Upvote:
                _vote++;
                break;
        }
    }
