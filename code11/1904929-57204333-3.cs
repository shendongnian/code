        var comments = await _unitOfWork.Repository<Comment>().Query()
    				.Include(x => x.User)
    				.Include(c => c.Post)
    				.Select(x => new CommentViewModel
    				{
    					User = _mapper.Map<User, UserViewModel>(x.User),
    					Post = _mapper.Map<Post, PostViewModel>(x.Post),
    					Comment = _mapper.Map<Comment, CommentDto>(x),
    				})
    				.ToListAsync();
