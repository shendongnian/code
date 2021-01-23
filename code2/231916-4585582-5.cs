    Imports System.Collections.ObjectModel
       
        Public Class ImageButtonCollection
            Inherits ObservableCollection(Of ImageButton)
        
            Public Sub New()
                For i As Integer = 1 To 300
                    Me.Add(New ImageButton(String.Format("C:\Images\image{0}.png", i), String.Format("Image{0}", i)))
                Next
            End Sub
        
        
        End Class
