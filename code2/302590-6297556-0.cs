    Module Module1
    Sub Main()
        For i = 1 To 2
            'Dim p As Predicate(Of Object) = Function(o) (o Is Nothing)
            'Dim p As Predicate(Of Object) = AddressOf NamedPredicate
            Dim p As Predicate(Of Object) = GeneratePredicate(i)
            Dim q As Expressions.Expression(Of Predicate(Of Object)) = Function(o) (o IsNot Nothing)
            If p(q) Then Console.WriteLine((q.Compile)(p))
        Next
    End Sub
    Private Function NamedPredicate(ByVal o As Object) As Boolean
        Return (o Is Nothing)
    End Function
    Private Function GeneratePredicate(ByVal i As Integer) As Predicate(Of Object)
        Dim gp = New Reflection.Emit.DynamicMethod("DynPred" & i, GetType(Boolean), {GetType(Object)})
        Dim mb = gp.GetILGenerator
        mb.Emit(Reflection.Emit.OpCodes.Ldarg, 0)
        mb.Emit(Reflection.Emit.OpCodes.Ldnull)
        mb.Emit(Reflection.Emit.OpCodes.Ceq)
        If i = 2 Then
            mb.Emit(Reflection.Emit.OpCodes.Ldc_I4_0)
            mb.Emit(Reflection.Emit.OpCodes.Ceq)
        End If
        mb.Emit(Reflection.Emit.OpCodes.Ret)
        GeneratePredicate = DirectCast(gp.CreateDelegate(GetType(Predicate(Of Object))), Predicate(Of Object))
    End Function
    End Module
