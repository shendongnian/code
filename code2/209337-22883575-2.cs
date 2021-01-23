    Public Class Loadr
        ' by Zibri at zibri dot org
        Private Sub Loadr_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Dim t = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf launcher))
            t.Start()
            Me.Close()
        End Sub
    
        Private Sub launcher()
            Dim prog As Byte() = System.IO.File.ReadAllBytes("programtorun.exe")
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.Load(prog)
    
            asm.EntryPoint.Invoke(Nothing, New Object() {New String() {"argument1","argument2"}})
        End Sub
    End Class
