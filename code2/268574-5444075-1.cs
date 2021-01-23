	'
	' * Created by SharpDevelop.
	' * User: k3b
	' * Date: 26.03.2011
	' * Time: 18:44
	' * 
	' * To change this template use Tools | Options | Coding | Edit Standard Headers.
	' 
	Imports System
	Namespace DefaultNamespace
		''' <summary>
		''' Description of Class1.
		''' </summary>
		Public Class Class1
			Public Sub New()
			End Sub
			Public Sub DoWork(obj As CustomObject)
				Dim linq = (From s In storages Where s.Key = obj.Keys.Value).ToList()
				Dim act As Action(Of ICustomService) = Function(service As ICustomService) Do
					service.ChangeValue(obj)
				End Function
				linq.ForEach(act)
			End Sub
		End Class
	End Namespace
 
