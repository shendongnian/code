    Private Sub VScrollBar1_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If TypeOf (sender) Is VScrollBar Then
                    Dim scrollBar As VScrollBar = CType(sender, VScrollBar)
                    If TypeOf (scrollBar.Parent) Is KryptonExtendedGrid Then
                        Dim KryptonGrid As KryptonExtendedGrid = CType(scrollBar.Parent, KryptonExtendedGrid)
                        If KryptonGrid.ScrollControl IsNot Nothing Then
                            If KryptonGrid.ScrollBars = ScrollBars.Vertical  Then
                                KryptonGrid.ScrollBars = ScrollBars.None
                                KryptonGrid.ScrollControl.DownButton.Enabled = True
                            Else
                                KryptonGrid.ScrollControl.DownButton.Enabled = False
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
    
            End Try
        End Sub
