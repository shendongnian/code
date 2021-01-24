    public string SetIsVisible(MessageEventArgs e, bool isVisible)
    {
        JObject body = JObject.Parse(e.Data);
        body["item-visible"] = isVisible;
        return body.ToString();
    }
