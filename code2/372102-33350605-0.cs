    Public Class ManuallyScrollingPanel
      Inherits Panel
    
      Public WithEvents sbar As New System.Windows.Forms.VScrollBar
    
      Sub New()
        MyBase.New()
        Controls.Add(sbar)
        sbar.Visible = True
        Me.AutoScroll = False
      End Sub
    
      Sub SetScrollParams()
        If PanelPositions.Any Then
          Dim NewMax = CInt((From item In PanelPositions.Values Select item.Bottom).Max + 500) - Height
          If sbar.Maximum <> NewMax Then
            sbar.Maximum = NewMax
          End If
        End If
      End Sub
    
      Public Sub RegisterChildSize(pnl As Panel, DesiredBounds As Drawing.Rectangle)
        PanelPositions(pnl) = DesiredBounds
        SetScrollParams()
      End Sub
    
      Dim PanelPositions As New Dictionary(Of Panel, Drawing.Rectangle)
    
      Private Sub ManuallyScrollingPanel_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        sbar.Top = 0
        sbar.Left = Width - sbar.Width
        sbar.Height = Me.Height
        SetScrollParams()
        sbar.LargeChange = CInt(Height * 0.9)
        sbar.SmallChange = CInt(Height * 0.2)
      End Sub
    
      Private Sub sb_Scroll(sender As Object, e As ScrollEventArgs) Handles sbar.Scroll
        ScrollTo(e.NewValue)
      End Sub
    
      Private Sub sb_ValueChanged(sender As Object, e As EventArgs) Handles sbar.ValueChanged
        ScrollTo(sbar.Value)
      End Sub
    
      Sub ScrollTo(pos As Integer)
        Me.AutoScroll = False
        For Each kvp In PanelPositions
          Dim VirtBounds = New Drawing.Rectangle(CInt(kvp.Value.Left), CInt(kvp.Value.Top - pos), CInt(kvp.Value.Width), CInt(kvp.Value.Height))
          If VirtBounds.Bottom < 0 Or VirtBounds.Top > Height Then
            ' it's not visible - hide it and position offscreen
            kvp.Key.Visible = False
            kvp.Key.Top = VirtBounds.Top
          Else
            ' Visible, position it
            kvp.Key.Top = VirtBounds.Top
            kvp.Key.Visible = True
          End If
        Next
      End Sub
    
    End Class
