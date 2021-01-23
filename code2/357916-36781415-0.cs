    byte[] toPost = System.Text.Encoding.UTF8.GetBytes(
        String.Join("&", formVars.Select(x =>
            HttpUtility.UrlEncode(x.Key) + "=" +
            HttpUtility.UrlEncode(x.Value)));
    );
