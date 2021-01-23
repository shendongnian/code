      Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Using e
            ##Add conditions to avoid OutOfMemoryException##
            If (Not ClientRectangle.Width = 0) And (Not ClientRectangle.Height = 0) Then
                Using rect As GraphicsPath = New GraphicsPath()
                    rect.AddRectangle(ClientRectangle)
                    Using gb As New PathGradientBrush(rect)
                        gb.WrapMode = WrapMode.Tile
                        gb.SurroundColors = New Color() {GradientColors(1), GradientColors(0), GradientColors(2)}
                        gb.CenterColor = GradientColors(0)
                        gb.SetSigmaBellShape(0.5F)
                        e.Graphics.FillPath(gb, rect)
                    End Using
                End Using
            End If
        End Using
    End Sub
