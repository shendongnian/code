      Public Shared Function GenericClone(ByVal Obj As Object) As Object
            
            Dim out As Object
            out = Activator.CreateInstance(Obj.GetType)
            Dim mytype As Type = Obj.GetType()
            While mytype IsNot Nothing
                For Each item As System.Reflection.FieldInfo In mytype.GetFields(Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance)
                    Dim itemValue As Object = item.GetValue(Obj)
                    Dim newvalue As Object = Nothing
                    If itemValue IsNot Nothing Then
                        If GetType(System.ICloneable).IsAssignableFrom(itemValue.GetType) Then
                            newvalue = CType(itemValue, System.ICloneable).Clone
                        Else
                            If itemValue.GetType.IsValueType Then
                                newvalue = itemValue
                            Else
                                If itemValue.GetType.Name = "Dictionary`2" Then
                                    newvalue = DataInterface.CloneDictionary(itemValue)
                                ElseIf itemValue.GetType Is GetType(System.Text.StringBuilder) Then
                                    newvalue = New System.Text.StringBuilder(CType(itemValue, System.Text.StringBuilder).ToString)
                                ElseIf itemValue.GetType.Name = "List`1" Then
                                    newvalue = DataInterface.CloneList(itemValue)
                                Else
                                    Throw (New Exception(item.Name & ", member of " & mytype.Name & " is not cloneable or of value type."))
                                End If
                            End If
                        End If
                    End If
                    'set new obj copied data
                    mytype.GetField(item.Name, Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance).SetValue(out, newvalue)
                Next
                'must move up to base type, GetFields does not return inherited fields
                mytype = mytype.BaseType
            End While
            Return out
        End Function
        Public Shared Function CloneDictionary(Of K, V)(ByVal dict As Dictionary(Of K, V)) As Dictionary(Of K, V)
            Dim newDict As Dictionary(Of K, V) = Nothing
            ' The clone method is immune to the source dictionary being null.
            If dict IsNot Nothing Then
                ' If the key and value are value types, clone without serialization.
                If ((GetType(K).IsValueType OrElse GetType(K) Is GetType(String)) AndAlso (GetType(V).IsValueType) OrElse GetType(V) Is GetType(String)) Then
                    newDict = New Dictionary(Of K, V)()
                    ' Clone by copying the value types.
                    For Each kvp As KeyValuePair(Of K, V) In dict
                        newDict(kvp.Key) = kvp.Value
                    Next
                Else
                    newDict = New Dictionary(Of K, V)()
                    ' Clone by copying the value types.
                    For Each kvp As KeyValuePair(Of K, V) In dict
                        newDict(kvp.Key) = DataInterface.GenericClone(kvp.Value)
                    Next
                End If
            End If
            Return newDict
        End Function
        Public Shared Function CloneList(Of T)(ByVal list As List(Of T)) As List(Of T)
            Dim Out As New List(Of T)
            If GetType(System.ICloneable).IsAssignableFrom(GetType(T)) Then
                Return (From x In list Select CType(CType(x, ICloneable).Clone, T)).ToList
            ElseIf GetType(T).IsValueType Then
                Return (From x In list Select CType(x, T)).ToList
            Else
                Throw New InvalidOperationException("List elements not of value or cloneable type.")
            End If
        End Function
