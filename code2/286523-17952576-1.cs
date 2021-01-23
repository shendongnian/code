	''' <summary>
	''' Determines whether the specified object context has changes from original DB values.
	''' </summary>
	''' <param name="objectContext">The object context.</param>
	''' <returns>
	'''   <c>true</c> if the specified object context is dirty; otherwise, <c>false</c>.
	''' </returns>
	<System.Runtime.CompilerServices.Extension()> _
	Public Function IsDirty(ByVal objectContext As ObjectContext) As Boolean
		Return objectContext.ObjectStateManager.GetObjectStateEntries(
				EntityState.Added Or EntityState.Deleted Or EntityState.Modified).Any()
	End Function
