public ViewResult Index(int? Id)
        {
            BooksIndexViewModel viewModel = new BooksIndexViewModel()
            {
                Books = _booksRepository.GetAllBooks(),
                AuthorOptions = new SelectList(_authorRepository.GetAllAuthors()
                    .Select(x => new { x.Id, Title = x.Name + " " + x.Lastname }), "Id", "Title"),
                Book = _booksRepository.GetBook(Id),
                publishers = _publisherRepository.GetAllPublishers(),
                indexPage = _dataRepository.Generatedata("Knygos", Id,
                    ControllerContext.RouteData.Values["controller"].ToString())
            };
            if (Id != null)
                viewModel.AuthorIds = _booksRepository.GetBook(Id).BookAuthors.Select(x => x.AuthorId).ToList();
            return View(viewModel);
        }
**cshtml**
<form asp-controller="@Model.indexPage.controller" asp-action="@Model.indexPage.action"
          asp-route-id="@if (Model.indexPage.routeId.HasValue) {@Model.indexPage.routeId.Value}" 
          method="post" class="form grid">
        <div class="inputs">
            <div><input asp-for="@Model.Book.Title" class="w100" /></div>
            <div><select asp-for="@Model.AuthorIds" asp-items="@Model.AuthorOptions"
                name="author[]" multiple></select></div>
            <div><select asp-for="@Model.Book.PublisherId" 
                        asp-items="@(new SelectList(Model.publishers, "Id", "Title"))">
            </select></div>
            <div><input asp-for="@Model.Book.Cost" /></div>
            <div><input asp-for="@Model.Book.Code" /></div>
            <div><input asp-for="@Model.Book.InvNr" /></div>
            <div><input asp-for="@Model.Book.Description" /></div>
        </div>
        <button type="submit">Save</button>
    </form>
Nothing else has changed.
