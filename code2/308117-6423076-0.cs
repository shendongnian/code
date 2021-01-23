    public static string ShowSubItems(this HtmlHelper helper, MyObject _object)
    {
         StringBuilder output = new StringBuilder();
         if(_object.ListOfObjects.Count > 0)
         {
             output.Append("<ul>");
             foreach(MyObject subItem in _object.listOfObjects)
             {
                 output.Append("<li>");
                 output.Append(_object.Title);
                 output.Append(html.ShowSubItems(subItem.listOfObjects);
                 output.Append("</li>")
             }
             output.Append("</ul>");
         }
         return output.ToString();
    }
