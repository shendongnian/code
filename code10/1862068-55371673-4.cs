    private void ButtonActionForFavouriteTriggered(object seletecedButtonItem)
        {
            System.Diagnostics.Debug.WriteLine("favourite button clickked");
            var selectedList = (Result)seletecedButtonItem;
            if (selectedList.isFavorite == "Fav.png")
            {
                // update api or local DB whatever on here
                selectedList.isUserFavorite = false;
                selectedList.isFavorite = "unFav.png"; // this will update in UI - changes from favorite image into unfavorite image
            }
            else
            {
                // update api or local DB whatever on here
                selectedList.isUserFavorite = true;
                selectedList.favourite = "Fav.png"; // this will update in UI
            }
        }
