        foreach (string nextRole in allRoles)
        {
            if (Array.IndexOf(roles, nextRole) != -1)
            {
                Response.Write(nextRole + "<br/>");
            }
        }
