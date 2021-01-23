                oReader = Me.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection Or CommandBehavior.KeyInfo)
    #If DbDebug Then
            'load method internally advances to the next result set
            'therefore, must check to see if reader is closed instead of calling next result
            Do
                Dim oTable As New DataTable("Table")
                oTable.Load(oReader)
                'Inspect oTable here as needed.
                oTable.WriteXml("C:\" + Environment.TickCount.ToString + ".xml")
                oTable.Dispose()
            Loop While oReader.IsClosed = False
            'must re-open the connection
            Me.SelectCommand.Connection.Open()
            'reload data reader
            oReader = Me.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection Or CommandBehavior.KeyInfo)
    #End If
