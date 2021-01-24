    private IEnumerable<SelectListItem> GetSelectList<T>(IEnumerable<T> dataSource, bool blankListItem = false) where T : BaseClassForDbSets
        {
            var selectListItems = dataSource 
                  .Select(listItem => new SelectListItem
                  {
                      Value = listItem.Id.ToString(),
                      Text = listItem.Name
                  }
                  ).ToList();
            if (blankListItem)
                selectListItems.Insert(0, (new SelectListItem { Text = $"Choose {nameof(T)}", Value = "" }));
            return selectListItems;
        }
