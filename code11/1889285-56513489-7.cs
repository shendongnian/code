     con.ConnectionString = dbProvider & dbSource
     con.Open()
     Dim userIdPro = Transfer.userIdPro
     // Don't concatenate your parameters. This is a bad practice and
     // exposes your application to SQL injection attacks. Use SQL
     // parameters instead.
     Dim query = ("SELECT Image FROM User_info WHERE ID = " & userIdPro & ";")
     Dim ds As New DataSet
     Dim dr As OleDb.OleDbDataReader
     Dim cm = New OleDb.OleDbCommand(query, con)
     dr = cm.ExecuteReader
     While dr.Read()
         Dim MyByte = dr.Item("Value")
         Dim MyImg As Image
         If MyByte IsNot Nothing Then
            // You do not need to save it, just convert to an image
            // type and set it to your PictureBox1 control.
            MyImg = bytesToImage(MyByte)
            PictureBox1.Image = MyImg
         End If
    End While
    con.Close()
