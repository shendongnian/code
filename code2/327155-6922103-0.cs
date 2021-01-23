            ' Generate Report
            byteArray = GenerateReport();
            ' Present the generated PDF to the user
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", byteArray.Length.ToString())
            Response.BinaryWrite(byteArray)
            Response.Flush()
            Response.Close()
