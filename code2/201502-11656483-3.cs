    	Public Shared Sub dt2json(ByVal _dt As DataTable, ByVal _sb As StringBuilder)
		Dim t As System.Type
		Dim oList(_dt.Rows.Count - 1) As Object
		Dim jss As New JavaScriptSerializer()
		Dim i As Integer = 0
		t = CompileResultType(_dt)
		For Each dr As DataRow In _dt.Rows
			Dim o As Object = Activator.CreateInstance(t)
			For Each col As DataColumn In _dt.Columns
				setvalue(o, col.ColumnName, dr.Item(col.ColumnName))
			Next
			oList(i) = o
			i += 1
		Next
		jss = New JavaScriptSerializer()
		jss.Serialize(oList, _sb)
	End Sub
