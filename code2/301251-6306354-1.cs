    document.Add(par);
    StyleSheet styles = new StyleSheet();
    string tempText = textItem.ContentElement.Text;
    tempText = tempText.Replace("\"", "&#34;");
    ArrayList objects = HTMLWorker.ParseToList(new StringReader(tempText), styles);
    for (int k = 0; k < objects.Count; ++k)
    {
        document.Add((IElement)objects[k]);
    }
