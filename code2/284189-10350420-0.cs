    Public Shared Function TableFromCommand(ByVal Command As SqlCommand) As DataTable
        Dim Cn As SqlConnection = Nothing
        Dim Dt As DataTable
        Dim Dr As SqlDataReader
        Dim Column As DataColumn
        Dim Answer As New DataTable
        Try
            Answer.TableName = "SearchTable"
            Cn = New SqlConnection("Your connection string")
            Cn.Open()
            Command.Connection = Cn
            For Each Prm As SqlParameter In Command.Parameters
                If Prm.Direction = ParameterDirection.Input _
                OrElse Prm.Direction = ParameterDirection.InputOutput Then
                    Prm.Value = DBNull.Value
                End If
            Next
            Dr = Command.ExecuteReader(CommandBehavior.SchemaOnly Or CommandBehavior.KeyInfo)
            Dt = Dr.GetSchemaTable
            Dim Keys As New List(Of DataColumn)
            Dim ColumnsDic As New SortedDictionary(Of Integer, DataColumn)
            For Each Row As DataRow In Dt.Rows
                Column = New DataColumn
                With Column
                    .ColumnName = Row("ColumnName").ToString
                    .DataType = Type.GetType(Row("DataType").ToString)
                    .AllowDBNull = CBool(Row("AllowDBNull"))
                    .Unique = CBool(Row("IsUnique"))
                    .ReadOnly = CBool(Row("IsReadOnly"))
                    If Type.GetType(Row("DataType").ToString) Is GetType(String) Then
                        .MaxLength = CInt(Row("ColumnSize"))
                    End If
                    If CBool(Row("IsIdentity")) = True Then
                        .AutoIncrement = True
                        .AutoIncrementSeed = -1
                        .AutoIncrementStep = -1
                    End If
                    If CBool(Row("IsKey")) = True Then
                        Keys.Add(Column)
                    End If
                End With
                ColumnsDic.Add(CInt(Row("ColumnOrdinal")), Column)
                Answer.Columns.Add(Column)
            Next
            If Keys.Count > 0 Then
                Answer.Constraints.Add("PrimaryKey", Keys.ToArray, True)
            End If
        Catch ex As Exception
            MyError.Show(ex)
        Finally
            If Cn IsNot Nothing AndAlso Not Cn.State = ConnectionState.Closed Then
                Cn.Close()
            End If
        End Try
        Return Answer
    End Function
