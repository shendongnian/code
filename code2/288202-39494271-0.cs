        Public Class DateTimePickerNullable
        Inherits DateTimePicker
    
        Public Shadows Event GotFocus(sender As Object, e As EventArgs)
        Public Shadows Event LostFocus(sender As Object, e As EventArgs)
    
        Private fvalue As DateTime?
        Private NoValueChange As Boolean = False
        Public Shadows Property Value As DateTime?
            Get
                Return fvalue
            End Get
            Set(value As DateTime?)
                fvalue = value
                If fvalue Is Nothing Then
                    Me.Format = DateTimePickerFormat.Custom
                    Me.CustomFormat = Space(Now.ToShortDateString.Length)
                    NoValueChange = True
                    MyBase.Value = Now
                    NoValueChange = False
                Else
                    Me.Format = DateTimePickerFormat.Short
                    NoValueChange = True
                    MyBase.Value = value.Value
                    NoValueChange = False
                End If
            End Set
        End Property
    
        Protected Overrides Sub OnValueChanged(eventargs As EventArgs)
            If Not NoValueChange Then
                Value = MyBase.Value
            End If
            MyBase.OnValueChanged(eventargs)
        End Sub
    
        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            If e.KeyCode = Keys.Delete Then
                Value = Nothing
            End If
            If Me.Format = DateTimePickerFormat.Custom Then
                Try
                    If Char.IsNumber(ChrW(e.KeyCode)) Then
                        If Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern.ToLower.StartsWith("m") Then
                            Value = New Date(Now.Year, CInt(ChrW(e.KeyCode).ToString), Now.Day)
                        Else
                            Value = New Date(Now.Year, Now.Month, CInt(ChrW(e.KeyCode).ToString))
                        End If
                        SendKeys.Send(ChrW(e.KeyCode))
                        Exit Sub
                    End If
                Catch
                End Try
            End If
            MyBase.OnKeyDown(e)
        End Sub
    
        Private HasFocus As Boolean = False
        Protected Overrides Sub OnGotFocus(e As EventArgs)
            MyBase.OnGotFocus(e)
            If Not HasFocus Then
                HasFocus = True
                RaiseEvent GotFocus(Me, New EventArgs)
            End If
        End Sub
    
        Protected Overrides Sub OnValidated(e As EventArgs)
            MyBase.OnValidated(e)
            HasFocus = False
            RaiseEvent LostFocus(Me, New EventArgs)
        End Sub
    End Class
