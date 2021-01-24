    private void ButtonActionForFavouriteTriggered(object seletecedButtonItem)
        {
            System.Diagnostics.Debug.WriteLine("favourite button clickked");
            var selectedList = (Result)seletecedButtonItem;
            if (selectedList.isFavorite == true)
            {
                // update api or local DB whatever on here
                selectedList.favourite = "unFav.png";
                selectedList.isFavorite = false;
            }
            else
            {
                // update api or local DB whatever on here
                selectedList.favourite = "Fav.png";
                selectedList.isFavorite = true;
            }
        }
