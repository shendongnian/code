    public class DataTableOptions
    {
        public string ID { get; set; }
        public string Url { get; set; }
        public string Cols { get; set; }
        public bool Sort { get; set; }
        public string ViewUrlLinkname { get; set; }
        public string EditUrlLinkname { get; set; }
        public string DeleteLinkname { get; set; }
        public string DeleteTitle { get; set; }
        public string DeleteYes { get; set; }
        public string DeleteNo { get; set; }
        public string DeleteMessage { get; set; }
    }
    
    public static class DataTableHelpers
    {
        private static string aLengthMenu = "[[25, 50, 100, 150, 200], [25, 50, 100, 150, 200]]";
        
        public static MvcHtmlString DataTable(this HtmlHelper helper, DataTableOptions options)
        {
            string[] arrcols = options.Cols.Split(',');
            int sortOffset = arrcols.Where(x => x == "Delete" || x == "View" || x == "Edit").Count();
            
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("<script type=\"text/javascript\" charset=\"utf-8\">");
            sb.AppendLine("$(function () {");
            sb.AppendLine("$('#" + options.ID + "').dataTable({");
            sb.AppendLine("\"bSort\" : " + options.Sort.ToString().ToLower() + ",");
            sb.AppendLine("\"oLanguage\": { \"sUrl\": \"" + oLanguage + "\" },");
            sb.AppendLine("\"bServerSide\": true,");
            sb.AppendLine("\"sAjaxSource\": \"" + options.Url + "\",");
            sb.AppendLine("\"bProcessing\": true,");
            sb.AppendLine("\"sPaginationType\": \"full_numbers\",");
            sb.AppendLine("\"iDisplayLength\": 25,");
            sb.AppendLine("\"aLengthMenu\": " + aLengthMenu + ",");
            sb.AppendLine("\"aaSorting\": [[" + sortOffset.ToString() + ",'asc']],");
            sb.AppendLine("\"aoColumns\": [");
            
    
            for (int i = 0; i < arrcols.Length; i++)
            {
                if (i > 0)
                    sb.Append(",");
    
                switch (arrcols[i])
                {
                    case "Delete":
                        sb.AppendLine("{");
                        sb.AppendLine("\"sName\": \"" + arrcols[i] + "\",");
                        sb.AppendLine("\"bSearchable\": false,");
                        sb.AppendLine("\"bSortable\": false,");
                        sb.AppendLine("\"fnRender\": function (oObj) {");
                        sb.Append("return '");
                        sb.Append("<a class=\"deletelink\" href=\"' + oObj.aData["+ i.ToString() + "] + '\">" + options.DeleteLinkname + "</a> ");
                        sb.Append("';");
                        sb.AppendLine("}");
                        sb.AppendLine("}");
    
                        break;
                    case "Edit":
                        sb.AppendLine("{");
                        sb.AppendLine("\"sName\": \"" + arrcols[i] + "\",");
                        sb.AppendLine("\"bSearchable\": false,");
                        sb.AppendLine("\"bSortable\": false,");
                        sb.AppendLine("\"fnRender\": function (oObj) {");
                        sb.Append("return '");
                        sb.Append("<a class=\"editlink\" href=\"' + oObj.aData["+ i.ToString() + "] +'\">" + options.EditUrlLinkname + "</a> ");
                        sb.Append("';");
                        sb.AppendLine("}");
                        sb.AppendLine("}");
    
                        break;
                    case "View":
                        sb.AppendLine("{");
                        sb.AppendLine("\"sName\": \"" + arrcols[i] + "\",");
                        sb.AppendLine("\"bSearchable\": false,");
                        sb.AppendLine("\"bSortable\": false,");
                        sb.AppendLine("\"fnRender\": function (oObj) {");
                        sb.Append("return '");
                        sb.Append("<a class=\"viewlink\" href=\"' + oObj.aData["+ i.ToString() + "] + '\">" + options.ViewUrlLinkname + "</a> ");
                        sb.Append("';");
                        sb.AppendLine("}");
                        sb.AppendLine("}");
    
                        break;
                    default:
                        sb.AppendLine("{ \"sName\": \"" + arrcols[i] + "\" }");
                        break;
                }
    
            }
    
            sb.AppendLine("]");
            sb.AppendLine("});");
            sb.AppendLine("});");
            sb.AppendLine("</script>");
    
            if (options.DeleteLinkname != null)
            {
                sb.Append(ConfirmHelpers.RenderConfirm(options.DeleteTitle, options.DeleteYes, options.DeleteNo, options.DeleteMessage));
            }
    
            return MvcHtmlString.Create(sb.ToString());
        }
