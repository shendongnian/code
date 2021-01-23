	public ViewResult List([DefaultValue(0)] string cityzip, [DefaultValue(1)] int page)
	{
	var roomsToShow = roomsRepository.Rooms.Join(
						roomCoordinatesRepository.RoomCoordinates,
						room => room.RoomID,
						roomCoordinate => roomCoordinate.RoomID,
						(room, roomCoordinate) => new RoomWithCoordinates{ Coordinates = roomCoordinate, Room = room } );
	var viewModel = new RoomsListViewModel
	{
		RoomsWithCoordinates = roomsToShow.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
		PagingInfo = new PagingInfo
		{
			CurrentPage = page,
			ItemsPerPage = PageSize,
			TotalItems = roomsToShow.Count()
		}
	};
	return View(viewModel); // Passed to view as ViewData.Model (or simply Model) 
	} 
