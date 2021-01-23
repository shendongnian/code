    public static class BulletList
    {
        public static string RenderList(List<BulletListItem> list) {
            var sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                sb.Append("<ul>");
                foreach(var item in list) {
                    sb.Append(item.Content);
                    sb.Append(BulletList.RenderList(item.Children));
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }
    }
    
    public class BulletListItem
    { 
        public string Content { get; set; }
        public List<BulletListItem> Children { get; set; }
    }
