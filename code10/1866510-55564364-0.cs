    var dto = new GetSortedPostsRequestDto
    {
        StartDate = inputForm.StartDatePicker.SelectedDate,
        SortMode = inputForm.GetSelectedSortMode()
    };
    var strategy = GetSortStrategy(dto);
    var results = unitOfWork.GetSortedPosts(strategy);
