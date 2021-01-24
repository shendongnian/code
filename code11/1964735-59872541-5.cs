    void CategoryButton_OnClicked(int objType)
    {
        ACResult[] matchingCategory = FilterResults(objType);
        if (objType != -1) // Assuming -1 means it's your "All" button.
        {
            //Pseudo function encapsulating your suggestion list rendering:
            ReRenderSuggestionList(matchingCategory);
        }
        else
        {
            //Your "All" button clears the cat filtering without reloading the results, which is why the FilterResults method doesn't alter the original "cachedResults" array.
            ReRenderSuggestionList(cachedResults);
        }
    }
