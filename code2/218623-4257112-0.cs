    Public Module ControlExtensionMethods
	''' <summary>
	''' Gets all validation controls used by a control.
	''' </summary>
	''' <param name="onlyGetVisible">If true, will only fetch validation controls that currently apply (i.e. that are visible). The default value is true.</param>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()>
	Public Function GetAllValidationControls(ByVal target As Control, Optional ByVal onlyGetVisible As Boolean = True) As ReadOnlyCollection(Of BaseValidator)
		Dim validators As New List(Of BaseValidator)
		GetControlsOfType(Of BaseValidator)(target, Function(x) Not onlyGetVisible OrElse x.Visible = onlyGetVisible, validators)
		Return validators.AsReadOnly()
	End Function
	''' <summary>
	''' Gets if the control is in a valid state (if all child/descendent validation controls return valid)
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<Extension()>
	Public Function IsValid(ByVal target As Control) As Boolean
		Return target.GetAllValidationControls().All(Function(x)
														 x.Validate()
														 Return x.IsValid
													 End Function)
	End Function
	''' <summary>
	''' Iteratively fetches all controls of a specified type/base type from a control and its descendents.
	''' </summary>
	''' <param name="fromControl"></param>
	''' <param name="predicate">If provided, will only return controls that match the provided predicate</param>
	''' <remarks></remarks>
	<Extension()>
	Public Function GetControlsOfType(Of T As Control)(ByVal fromControl As Control, Optional ByVal predicate As Predicate(Of T) = Nothing) As IList(Of T)
		Dim results As New List(Of T)
		GetControlsOfType(fromControl, predicate, results)
		Return results
	End Function
	Private Sub GetControlsOfType(Of T As Control)(ByVal fromControl As Control, ByVal predicate As Predicate(Of T), ByVal results As IList(Of T))
		'create default predicate that always returns true if none is provided
		Dim cntrl As Control
		If predicate Is Nothing Then predicate = Function(x) True
		If fromControl.HasControls Then
			For Each cntrl In fromControl.Controls
				GetControlsOfType(Of T)(cntrl, predicate, results)
			Next
		End If
		If TypeOf fromControl Is T AndAlso predicate(fromControl) Then
			results.Add(fromControl)
		End If
	End Sub
    End Module
