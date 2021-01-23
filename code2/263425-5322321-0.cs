    var reader = new StringReader(text);
    var styles = new StyleSheet();
    styles.LoadTagStyle("body", "face", "Arial");
    styles.LoadTagStyle("body", "size", fontSize + "px");
    styles.LoadTagStyle("body", "font-weight", "bold");
    ArrayList list = HTMLWorker.ParseToList(reader, styles);
    for (int k = 0; k < list.Count; k++)
    {
      var element = (IElement)list[k];
      if (element is Paragraph)
      {
        var paragraph = (Paragraph)element;
        paragraph.SpacingAfter = 10f;
        cell.AddElement(paragraph);
      }
     else
      cell.AddElement((IElement)list[k]);
    }
