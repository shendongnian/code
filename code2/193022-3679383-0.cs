        Public Const ThreadCount As Integer = 2
        Public thrdsWrite() As Threading.Thread = New Threading.Thread(ThreadCount - 1) {}
        Public thrdsRead() As Threading.Thread = New Threading.Thread(ThreadCount - 1) {}
        Public d As Int64
    
        <STAThread()> _
        Sub Main()
    
            For i As Integer = 0 To thrdsWrite.Length - 1
                thrdsWrite(i) = New Threading.Thread(AddressOf Write)
                thrdsWrite(i).SetApartmentState(Threading.ApartmentState.STA)
                thrdsWrite(i).IsBackground = True
                thrdsWrite(i).Start()
                thrdsRead(i) = New Threading.Thread(AddressOf Read)
                thrdsRead(i).SetApartmentState(Threading.ApartmentState.STA)
                thrdsRead(i).IsBackground = True
                thrdsRead(i).Start()
            Next
    
            Console.ReadKey()
    
        End Sub
    
        Public Sub Write()
    
            Dim rnd As New Random(DateTime.Now.Millisecond)
            While True
                d = If(rnd.Next(2) = 0, 0, Int64.MaxValue)
            End While
    
        End Sub
    
        Public Sub Read()
    
            While True
                Dim dc As Int64 = d
                If (dc <> 0) And (dc <> Int64.MaxValue) Then
                    Console.WriteLine(dc)
                End If
            End While
    
        End Sub
