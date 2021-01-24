    ''Sample class to hold datatables and their names
        Class cls_dtlist
            Public Property TableName As String
            Public Property Tabledata As DataTable
        End Class
    
        Sub Main()
    
            ''Dummy Tables
            Dim A As DataTable = New DataTable()
            Dim B As DataTable = New DataTable()
            Dim C As DataTable = New DataTable()
            Dim D As DataTable = New DataTable()
            Dim E As DataTable = New DataTable()
            Dim F As DataTable = New DataTable()
    
    
            Dim pathofXml As String = "your path"
    
    
            Dim dtlist As List(Of cls_dtlist) = New List(Of cls_dtlist)
    
            ''Adding datatables to class and then list
            dtlist.Add(New cls_dtlist With {.TableName = "A", .Tabledata = A})
            dtlist.Add(New cls_dtlist With {.TableName = "B", .Tabledata = B})
            dtlist.Add(New cls_dtlist With {.TableName = "C", .Tabledata = C})
            dtlist.Add(New cls_dtlist With {.TableName = "D", .Tabledata = D})
            dtlist.Add(New cls_dtlist With {.TableName = "E", .Tabledata = E})
            dtlist.Add(New cls_dtlist With {.TableName = "F", .Tabledata = F})
    
    
            Dim dsxml As DataSet = New DataSet()
    
            For Each dataTable In dtlist
    
                dataTable.TableName = dataTable.TableName
    
                dsxml.Tables.Add(dataTable.Tabledata.Copy())
            Next
    
            dsxml.WriteXml(Path)
    
        End Sub
