    List<PagesToLoad> GetPagesToload(int curItemIndex, int numItemsToGet, int itemsPerPage)
    {
        List<PagesToLoad> result = new List<pagesToLoad>();
        int firstPage = curItemIndex / itemsPerPage + 1;
        int startPos = curItemIndex % itemsPerPage + 1;
        int lastItemIndex = curItemIndex + numItemsToGet - 1;
        int lastPage = lastItemIndex / itemsPerPage + 1;
        int stopPos = lastItemIndex % itemsPerPage + 1;
        PagesToLoad page1 = new PagesToLoad();
        page1.Page = 1;
        page1.Skip = curItemIndex;
        page1.Take = numItemsToGet;
        if (numItemsToGet + startPos - 1 > itemsPerPage)
        {
            page1.Take = itemsPerPage - startPos + 1;
            result.Add(page1);
            for (int i = firstPage + 1; i < lastPage; i++)
            {
                PagesToAdd nextPage = new PagesToAdd();
                nextPage.Page = i;
                nextPage.Skip = 0;
                nextPage.Take = itemsPerPage;
                result.Add(nextPage);
            }
            PagesToAdd pageN = new PagesToAdd();
            pageN.Page = lastPage;
            pageN.Skip = 0;
            pageN.Take = stopPos;
            result.Add(pageN);
        }
        else
        {
            result.Add(page1);
        }
        return result;
    }
