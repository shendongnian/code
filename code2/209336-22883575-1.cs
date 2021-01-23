    Public Class Loadr
        ' by Zibri at zibri dot org
        Private Sub Loadr_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim th = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf launcher))
            th.Start()
            Me.Close()
        End Sub
    
        Private Sub launcher()
            Dim b As Byte() = System.IO.File.ReadAllBytes("programtorun.exe")
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.Load(b)
    
            asm.EntryPoint.Invoke(Nothing, New Object() {New String() {"argument1","argument2"}})
        End Sub
    End Class
