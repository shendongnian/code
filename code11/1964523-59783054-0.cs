    var cellContent = optValueColumn.GetCellContent(e.AddedCells.First().Item);
    if(cellContent is ContentPresenter presenter)
    {
        var content = presenter.Content;
    }
            
