    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DateTime?>" %>
    
    <%
        string controlId = ViewData.TemplateInfo.HtmlFieldPrefix.Replace('.', '_');
    %>
    
    <script type="text/javascript">
    $(function () {
        $('#<%: controlId %>_Day, #<%: controlId %>_Month, #<%: controlId %>_Year').change(function () { updateHiddenDate('<%: controlId %>'); });
    });
    
    function updateHiddenDate(hiddenDateId) {
        $('#' + hiddenDateId).val($('#' + hiddenDateId + '_Year').val() + "-" + $('#' + hiddenDateId + '_Month').val() + "-" + $('#' + hiddenDateId + '_Day').val());
    }
    </script>
    
    <select id="<%: controlId %>_Day">
    <%  for (int dayOrdinal = 1; dayOrdinal <= 31; dayOrdinal++)
        {
            Response.Write(string.Format("<option value=\"{0}\">{0}</option>", dayOrdinal));
        }
    %>
    </select>
    <select id="<%: controlId %>_Month">
    <%  for (int monthOrdinal = 1; monthOrdinal <= 12; monthOrdinal++)
        {
            Response.Write(string.Format("<option value=\"{0}\">{1}</option>", monthOrdinal, System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames[monthOrdinal - 1]));
        }
    %>
    </select>
    <select id="<%: controlId %>_Year">
    <%  for (int yearOrdinal = DateTime.Now.Year - 5; yearOrdinal <= DateTime.Now.Year + 5; yearOrdinal++)
        {
            Response.Write(string.Format("<option value=\"{0}\">{0}</option>", yearOrdinal));
        }
    %>
    </select>
    
    <%: Html.Hidden("", Model.HasValue ? String.Format("{0:yyyy-MM-dd}", Model) : "") %>
