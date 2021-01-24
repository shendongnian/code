	<table class="table">
	@using (Html.BeginForm("Bind", "Bind", FormMethod.Post))
	{
		for (int i = 0; i < Model.Count(); i++)
		{
			 <tr>
				 <td>
					 @Html.DisplayFor(modelItem => Model[i].CommunicationName)
				 </td>
				 <td>
					 @Html.CheckBoxFor(modelItem => Model[i].IsSelected)
				 </td>
			 </tr>
		 }
		<button type="submit">Submit</button>
	}
	</table>
