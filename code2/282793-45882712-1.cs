     Public Sub decryptFile(ByVal input As String, ByVal output As String)
            inputFile = New FileStream(input, FileMode.Open, FileAccess.Read)
            outputFile = New FileStream(output, FileMode.OpenOrCreate, FileAccess.Write)
            outputFile.SetLength(0)
            Dim buffer(4096) As Byte
            Dim bytesProcessed As Long = 0
            Dim fileLength As Long = inputFile.Length
            Dim bytesInCurrentBlock As Integer
            Dim rijandael As New RijndaelManaged
            Dim cryptoStream As CryptoStream = New CryptoStream(outputFile, rijandael.CreateDecryptor(encryptionKey, encryptionIV), CryptoStreamMode.Write)
            While bytesProcessed < fileLength
                bytesInCurrentBlock = inputFile.Read(buffer, 0, 4096)
                cryptoStream.Write(buffer, 0, bytesInCurrentBlock)
                bytesProcessed = bytesProcessed + CLng(bytesInCurrentBlock)
            End While
            Try
                cryptoStream.Close() 'this will raise error if wrong password used
                inputFile.Close()
                outputFile.Close()
                File.Delete(input)
                success += 1
            Catch ex As Exception
                fail += 1
                inputFile.Close()
                outputFile.Close()
                outputFile = Nothing
                File.Delete(output)
            End Try
