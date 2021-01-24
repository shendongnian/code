    public static bool IsOk(this HttpWebResponse response) {
        var isOk = response.IsSuccessStatusCode;
        isOk = isOk && response.StatusCode == 200;
        return isOk;
    }
