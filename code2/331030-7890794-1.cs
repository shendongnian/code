    // GET: /posts/comment
    [ChildActionOnly]
    public PartialViewResult Comment(PostViewModel viewModel)
    {
        viewModel.NewComment = new CommentViewModel(viewModel.PostID, viewModel.Slug);
        if (TempData.ContainsKey(commentFormModelStateKey))
        {
            ModelStateDictionary commentModelState = TempData[commentFormModelStateKey] as ModelStateDictionary;
            foreach (KeyValuePair<string, ModelState> valuePair in commentModelState)
                ModelState.Add(valuePair.Key, valuePair.Value);
        }
        return PartialView(viewModel.NewComment);
    }
