    public Controller(IEmailJobQueue emailJobQueue) {
      _emailJobQueue = emailJobQueue;
    }
    
    [HttpPost("add")]
    public async Task Add(objSaveModel obj)
    {
        Model model = _mapper.Map<Model>(objSaveModel);
        Model createdModel = await _repo.AddModel(model);
    
        await _emailJobQueue.EnqueueJobAsync(new EmailJob("user@stack.com", 11 /* template id */));
    }
