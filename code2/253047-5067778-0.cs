    public static class HtmlHelperExtensions
    {
        public static HtmlString SequentialNumber(this HtmlHelper html,int? sequence)
        {
            if(sequence!=null)
            {   
                 var tile = sequence;
                 html.ViewData["Tile"] = sequence + 1;
            }
            else
            {
                 var tile = (int)(html.ViewData["Tile"] ?? 1);
                 html.ViewData["Tile"] = tile + 1;
            }
            return new HtmlString(tile.ToString());
        }
    }
