    ' See the Main() task, where this is set
	Public Shared referencePath As String
	Public Sub New()
		AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve
	End Sub
    ''' <summary>
	''' The Ionic.zip reference isn't in the GAC, so we need to give the assembly resolver a hint as to where it resides:
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="args"></param>
	''' <returns></returns>
	Private Shared Function CurrentDomain_AssemblyResolve(ByVal sender As Object, ByVal args As ResolveEventArgs) As Reflection.Assembly
		If args.Name.ToLower.Contains("ionic.zip") Then
			Return Reflection.Assembly.LoadFile(Path.Combine(referencePath, "Ionic.zip.dll"))
		End If
		Return Nothing
	End Function
    Public Sub Main()
		' Set the static referencePath to our SSIS variable's value - we need to do this because the Ionic.Zip reference,
		' referred to in the ProcessEmails() method, will otherwise look in the GAC, and won't find what it's looking for.
		referencePath = Dts.Variables("ReferencePath").Value.ToString()
		Dts.TaskResult = ProcessEmails()
	End Sub
