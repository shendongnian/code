            var aspxItem = e.Item;
            var dataItem = (SearchResultData) e.Item.DataItem;
            if (dataItem is ContactSearchResult.ContactSearchResultData)
            {
                var contactSearchResultUC = LoadControl("~/UserControls/ResultsListingSearchResult/ContactSearchResult.ascx") as ASP.ContactSearchResult;
                contactSearchResultUC.data = (ContactSearchResult.ContactSearchResultData)dataItem;
                aspxItem.Controls.Add(contactSearchResultUC);
            }
            else if (dataItem is NewsArticleSearchResult.NewsArticleSearchResultData)
            {
                var newsArticleSearchResultUC = LoadControl("~/UserControls/ResultsListingSearchResult/NewsArticleSearchResult.ascx") as ASP.NewsArticleSearchResult;
                newsArticleSearchResultUC.data = (NewsArticleSearchResult.NewsArticleSearchResultData)dataItem;
                aspxItem.Controls.Add(newsArticleSearchResultUC);
            }
            ...etc
