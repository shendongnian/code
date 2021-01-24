    public ActionResult DetailsTest(int id)
    {
        var poll = _context.Polls.Include(c => c.PollOptions).Include(c1 => c1.Votes).SingleOrDefault(c => c.Id == id);
        List<PollOptionsViewModel> pollOptionsList = new List<PollOptionsViewModel>();
        var viewModel = new PollDetailViewModel
        {
            Poll = poll,
        };
        foreach(var pollOption in poll.PollOptions)
        {
            PollOptionsViewModel pollOptionsViewModel = new PollDetailViewModel
            {
                PollOptionsId = pollOption.PollOptionsId,
                VoteCount = pollOption.Votes.Count
            };
            pollOptionsList.Add(pollOptionsViewModel);
        }
        viewModel.PollOptionsViewModelList = pollOptionsList;
        return View(viewModel);
    }
