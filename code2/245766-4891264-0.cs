    [WebMethod]
    public string[] GetSearchResults(int authorityTypeId, string searchTerms)
    {
        if (authorityTypeId > 0 && searchTerms != string.Empty)
        {
            var authorities = from a in BusinessLayer.SearchAuthorities(authorityTypeId, searchTerms)
                              select a.Name;
            return authorities.ToArray();
        }
        else
        {
            return null;
        }
    }
