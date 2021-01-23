    Option Explicit On
    Option Strict On
    
    Public Class Progress
        Inherits System.Windows.Forms.UserControl
    
    #Region "Code for the Designer.vb class"
    
        Sub New()
            InitializeComponent()
        End Sub
        ''//Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    
        ''//Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer
    
        ''//NOTE: The following procedure is required by the Windows Form Designer
        ''//It can be modified using the Windows Form Designer.  
        ''//Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.btnCancel = New System.Windows.Forms.Button
            Me.lblPlaceholder = New System.Windows.Forms.Label
            Me.pb = New System.Windows.Forms.ProgressBar
            Me.SuspendLayout()
            ''//
            ''//btnCancel
            ''//
            Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnCancel.Location = New System.Drawing.Point(73, 33)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(91, 21)
            Me.btnCancel.TabIndex = 0
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            ''//
            ''//
            ''//lblPlaceholder
            ''//
            Me.lblPlaceholder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPlaceholder.BackColor = System.Drawing.Color.Transparent
            Me.lblPlaceholder.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPlaceholder.Location = New System.Drawing.Point(12, 3)
            Me.lblPlaceholder.Name = "lblPlaceholder"
            Me.lblPlaceholder.Size = New System.Drawing.Size(221, 29)
            Me.lblPlaceholder.TabIndex = 1
            Me.lblPlaceholder.Text = "Placeholder label for text drawing"
            Me.lblPlaceholder.Visible = False
            ''//
            ''//pb
            ''//
            Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pb.Location = New System.Drawing.Point(6, 60)
            Me.pb.Name = "pb"
            Me.pb.Size = New System.Drawing.Size(225, 10)
            Me.pb.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            Me.pb.TabIndex = 2
            ''//
            ''//ucProgress
            ''//
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Controls.Add(Me.pb)
            Me.Controls.Add(Me.lblPlaceholder)
            Me.Controls.Add(Me.btnCancel)
            Me.Name = "ucProgress"
            Me.Size = New System.Drawing.Size(236, 77)
            Me.ResumeLayout(False)
    
        End Sub
        Friend WithEvents btnCancel As System.Windows.Forms.Button
    
        Friend WithEvents lblPlaceholder As System.Windows.Forms.Label
        Public WithEvents pb As System.Windows.Forms.ProgressBar
    
    #End Region
    
        Dim _mymessage As String
        Public Event WorkerPart()
        Public Cancel As Boolean
    
        Public EnabledStates As New Dictionary(Of Control, Boolean)
        Dim oldfocus As Control
        Dim OldMinBox As Boolean
    
        Public Sub StartProgress()
            Cancel = False
            Me.Parent = Me.ParentForm
            oldfocus = Me.ParentForm.ActiveControl
            Parent_SizeChanged(Nothing, Nothing)
            AddHandler Me.ParentForm.SizeChanged, AddressOf Parent_SizeChanged
            Me.Visible = True
            Me.Enabled = True
            Me.btnCancel.Focus()
            EnabledStates.Clear()
            For Each ctl As Control In Me.Parent.Controls
                If ctl IsNot Me Then
                    EnabledStates.Add(ctl, ctl.Enabled)
                    ctl.Enabled = False
                End If
            Next
            Me.BringToFront()
            Me.pb.Value = 0
            OldMinBox = Me.ParentForm.MinimizeBox
            Me.ParentForm.MinimizeBox = True
        End Sub
    
        Public Sub EndProgress()
            RemoveHandler Me.ParentForm.SizeChanged, AddressOf Parent_SizeChanged
            For Each ctl As Control In Me.Parent.Controls
                If ctl IsNot Me And EnabledStates.ContainsKey(ctl) Then
                    ctl.Enabled = EnabledStates(ctl)
                End If
            Next
            If oldfocus IsNot Nothing Then
                oldfocus.Focus()
            End If
            Me.ParentForm.MinimizeBox = OldMinBox
            Me.Visible = False
        End Sub
    
        Public Property Message() As String
            Get
                Return _mymessage
            End Get
            Set(ByVal value As String)
                _mymessage = value
                Dim g As Graphics = Me.CreateGraphics()
                DrawString(g)
                g.Dispose()
                ''//lblMessage.Text = value
                Application.DoEvents()
            End Set
        End Property
    
        Private Sub DrawString(ByVal g As Graphics)
            ''//g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixel
            Dim rct As New Rectangle(Me.lblPlaceholder.Left, Me.lblPlaceholder.Top, _
               Me.lblPlaceholder.Width, Me.lblPlaceholder.Height)
            g.SetClip(rct)
            Dim b As New SolidBrush(Me.BackColor)
            If Me.BackgroundImage Is Nothing Then
                g.FillRectangle(b, rct)
            Else
                g.DrawImage(Me.BackgroundImage, 0, 0)
            End If
            ''//
            With lblPlaceholder
                g.DrawString(_mymessage, .Font, Brushes.DarkBlue, .Left, _
                 .Top + CInt(IIf(InStr(_mymessage, vbCrLf) <> 0, 0, .Height \ 4)))
            End With
        End Sub
    
        Private Sub frmProgress_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
            DrawString(e.Graphics)
        End Sub
    
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Cancel = True
        End Sub
    
        Private Sub Parent_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.Left = (Me.Parent.Width - Me.Width) \ 2
            Me.Top = (Me.Parent.Height - Me.Height) \ 2
        End Sub
    End Class
