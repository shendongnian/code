    private static string ToHash(IEnumerable<Weather> weatherResults)
    {
        using (var algorithm = MD5.Create())
        {
            var json = JsonConvert.SerializeObject(weatherResults);
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(json));
            return Convert.ToBase64String(hash);
        }
    }
