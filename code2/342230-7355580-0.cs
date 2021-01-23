        // ...
        var userName = GetUserNameFromToken(token);
        if (!string.IsNullOrEmpty(userName))
        {
            requestProperty.Headers["X-UserName"] = userName;
            return true;
        }
        // ...
