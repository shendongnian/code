    PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();
    var iterGroup = groups.GetEnumerator();
    using (iterGroup)
    {
        while (iterGroup.MoveNext())
        {
            try
            {
                Principal p = iterGroup.Current;
                Console.WriteLine(p.Name);
            }
            catch (NoMatchingPrincipalException pex)
            {
                continue;
            }
        }
    }
