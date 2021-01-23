    public static string GetAndClearMessages() {
    var list = (IList<KeyValuePair<string, string>>) Session[Index];
    var listTag = new TagBuilder("ul");
    var tags = new StringBuilder();
    foreach(var kvp in list)
        {
    
            var liTag = new TagBuilder("li");
            liTag.AddCssClass(kvp.Value);
            liTag.SetInnerText(kvp.Key.ToString());
            tags.AppendLine(liTag.ToString());
            listTag.InnerHtml = tags.ToString();
                
        }
        Session[Index] = null;
        return listTag.ToString();
    }
