    document.Add(par);
    StyleSheet styles = new StyleSheet();
    ArrayList objects = HTMLWorker.ParseToList(new StringReader(textItem.ContentElement.Text), styles);
    for (int k = 0; k < objects.Count; ++k)
    {
      document.Add((IElement)objects[k]);
    }
