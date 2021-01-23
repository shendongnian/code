	<script runat="server">
		
        private string[,] viewData;
		protected string[,] Data
		{
			get
			{
				return viewData ?? (viewData = (string[,])ViewData["weekDays"]);
			}
		}
		
	</script>
    <% for (var i=0; i< Data.GetUpperBound(0); i++) 
                   { %>
                    <option value=" <%= Data[i][0] %> "> ...
                <% } %>
