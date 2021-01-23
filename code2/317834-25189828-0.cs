        OpenFileDialog.Filter = "Spreadsheets (*.xls*)|*.xls*"
        OpenFileDialog.Multiselect = False
        Try
            If (OpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                objOffice = CreateObject("com.sun.star.ServiceManager") 'preparar instancia libreOffice (prepare libreOffice instance)
                instOffice = objOffice.createInstance("com.sun.star.frame.Desktop")
                Dim obj(-1) As Object
                Dim myDoc = instOffice.loadComponentFromURL("file:///" & OpenFileDialog.FileName.Replace("\", "/"), "_default", 0, obj)
                Dim hojas = myDoc.getSheets().getElementNames() 'Obtener nombres de las hojas de calculo (get Spreadsheet names)
                System.Threading.Thread.Sleep(1000) 'Esperar a que termine la instancia Office (await libreOffice thread)
                myDoc.Close(True)
                Dim MyConnection As System.Data.OleDb.OleDbConnection 'Preparar conexión para realizar consulta tipo sql (preparing connection)
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                '' Microsoft Office Compatibility Pack for Word, Excel, and PowerPoint File Formats and
                '' Microsoft Access Database Engine 2010 Redistributable (to get ACE.OLEDB.12.O connection without Office installation)
                If OpenFileDialog.FileName.ToUpper.Contains(".XLSX") Then
                    MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & OpenFileDialog.FileName & "';Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'")
                Else
                    MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & OpenFileDialog.FileName & "';Extended Properties='Excel 12.0;HDR=YES;IMEX=1'")
                End If
