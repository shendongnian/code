    Sub Main()
    
    	Dim dt As New DataTable()
    	dt.Columns.Add(New DataColumn With {
    		.ReadOnly = True,
    		.ColumnName = "Name",
    		.DataType = GetType(Integer)
    	})
    	
    	dt.Rows.Add(4)
    
    	Try
    		DoNothing(dt.Rows(0).Item("Name"))
            Console.WriteLine("All good")
    	Catch ex As Exception
    		Console.WriteLine(ex.Message)
    	End Try	
    
    End Sub
    
    Sub DoNothing(ByRef item As Object) 
    End Sub 
