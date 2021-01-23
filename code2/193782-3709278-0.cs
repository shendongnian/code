    Public Class Form1
      Dim MasterList As New List(Of String)
    
    
      Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim L As New List(Of String)
    
        L.Add("123123 - Bob")
        L.Add("534543 - Sally")
        L.Add("123123 - George")
        L.Add("34213 - Happy")
    
        MasterList = L
    
        Me.ClsCustomAutoCompleteTextbox1.AutoCompleteList = L
      End Sub
    
      Private Sub ClsCustomAutoCompleteTextbox1_BeforeDisplayingAutoComplete(ByVal sender As Object, ByVal e As clsCustomAutoCompleteTextbox.clsAutoCompleteEventArgs) Handles ClsCustomAutoCompleteTextbox1.BeforeDisplayingAutoComplete
    
        Dim Name As String = Me.ClsCustomAutoCompleteTextbox1.Text.ToLower
    
        Dim Display As New List(Of String)
    
        For Each Str As String In MasterList
          If Str.ToLower.IndexOf(Name) > -1 Then
            Display.Add(Str)
          End If
        Next
    
        e.AutoCompleteList = Display
        e.SelectedIndex = 0
      End Sub
    End Class
    
    
    #Region "clsCustomAutoCompleteTextbox"
    Public Class clsCustomAutoCompleteTextbox
      Inherits TextBox
      Event BeforeDisplayingAutoComplete(ByVal sender As Object, ByVal e As clsAutoCompleteEventArgs)
      Event ItemSelected(ByVal sender As Object, ByVal e As clsItemSelectedEventArgs)
    
    
      Public test As New List(Of String)
      Public Tabs As Integer = 0
    
    
      Private Function GetLastFunction(Optional ByVal Deep As Integer = 1) As System.Reflection.MethodInfo
        Dim ST As New StackTrace
        Dim Frame As StackFrame = ST.GetFrame(Deep)
    
        Return Frame.GetMethod()
      End Function
    
      Private Sub TempLogStart()
        'Dim Meth As System.Reflection.MethodInfo = GetLastFunction(3)
    
        'test.Add(Now & " - " & New String(" ", Tabs * 2) & "Started " & Meth.Module.Name & "." & Meth.Name)
    
        'Tabs += 1
      End Sub
    
      Private Sub TempLogStop()
        '  Dim Meth As System.Reflection.MethodInfo = GetLastFunction(3)
    
        '  Tabs -= 1
    
        '  test.Add(Now & " - " & New String(" ", Tabs * 2) & "Stopped " & Meth.Module.Name & "." & Meth.Name)
      End Sub
    
      Public Enum SelectOptions
        OnEnterPress = 1
        OnSingleClick = 2
        OnDoubleClick = 4
        OnTabPress = 8
        OnRightArrow = 16
        OnEnterSingleClick = 3
        OnEnterSingleDoubleClicks = 7
        OnEnterDoubleClick = 5
        OnEnterTab = 9
        'OnItemChange = 32
      End Enum
    
      Private mSelStart As Integer
      Private mSelLength As Integer
    
      Private myAutoCompleteList As New List(Of String)
      Private WithEvents myLbox As New ListBox
      Private WithEvents myForm As New Form
      Private WithEvents myParentForm As Form
    
      Private DontHide As Boolean = False
      Private SuspendFocus As Boolean = False
    
      Dim Args As clsAutoCompleteEventArgs
    
      WithEvents HideTimer As New Timer()
      WithEvents FocusTimer As New Timer()
    
      Private myShowAutoCompleteOnFocus As Boolean
      Private myAutoCompleteFormBorder As System.Windows.Forms.FormBorderStyle = FormBorderStyle.None
      Private myOnEnterSelect As Boolean
      Private mySelectionMethods As SelectOptions = (SelectOptions.OnDoubleClick Or SelectOptions.OnEnterPress)
      Private mySelectTextAfterItemSelect As Boolean = True
    
    
      Public Property SelectTextAfterItemSelect() As Boolean
        Get
          Return mySelectTextAfterItemSelect
        End Get
        Set(ByVal value As Boolean)
          mySelectTextAfterItemSelect = value
        End Set
      End Property
    
      <System.ComponentModel.Browsable(False)> _
      Public Property SelectionMethods() As SelectOptions
        Get
          Return mySelectionMethods
        End Get
        Set(ByVal value As SelectOptions)
          mySelectionMethods = value
        End Set
      End Property
    
      Public Property OnEnterSelect() As Boolean
        Get
          Return myOnEnterSelect
        End Get
        Set(ByVal value As Boolean)
          myOnEnterSelect = value
        End Set
      End Property
    
      Public Property AutoCompleteFormBorder() As System.Windows.Forms.FormBorderStyle
        Get
          Return myAutoCompleteFormBorder
        End Get
        Set(ByVal value As System.Windows.Forms.FormBorderStyle)
          myAutoCompleteFormBorder = value
        End Set
      End Property
    
      Public Property ShowAutoCompleteOnFocus() As Boolean
        Get
          Return myShowAutoCompleteOnFocus
        End Get
        Set(ByVal value As Boolean)
          myShowAutoCompleteOnFocus = value
        End Set
      End Property
    
      Public ReadOnly Property Lbox() As ListBox
        Get
          Return myLbox
        End Get
      End Property
    
      Public Property AutoCompleteList() As List(Of String)
        Get
          Return myAutoCompleteList
        End Get
        Set(ByVal value As List(Of String))
          myAutoCompleteList = value
        End Set
      End Property
    
      Private Sub TryHideFormWindowsDeactivated()
    
      End Sub
    
      Private Declare Auto Function GetForegroundWindow Lib "user32.dll" () As IntPtr
      Private Declare Auto Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hWnd As IntPtr, ByRef ProcessID As Integer) As Integer
    
      Private Function IsCurProcess(ByVal P As Process) As Boolean
        Dim Ptr As IntPtr = P.MainWindowHandle
    
    
      End Function
    
      Private Function AppHasFocus(Optional ByVal ExeNameWithoutExtension As String = "") As Boolean
        Dim Out As Boolean = False
        Dim PID As Integer = 0
    
        TempLogStart()
    
        If ExeNameWithoutExtension = "" Then
          ExeNameWithoutExtension = Process.GetCurrentProcess.ProcessName
        End If
        Dim activeHandle As IntPtr = GetForegroundWindow()
        Call GetWindowThreadProcessId(activeHandle, PID)
        If PID > 0 Then
          'For Each p As Process In Process.GetProcessesByName(ExeNameWithoutExtension)
          If PID = Process.GetCurrentProcess.Id Then
            Out = True
            'Exit For
          End If
          ' Next
        End If
    
        TempLogStop()
    
        Return Out
      End Function
    
      Private Sub SaveSelects()
        Me.mSelStart = Me.SelectionStart
        Me.mSelLength = Me.SelectionLength
      End Sub
    
      Private Sub LoadSelects()
        Me.SelectionStart = Me.mSelStart
        Me.SelectionLength = Me.mSelLength
      End Sub
    
      Private Sub ShowAutoComplete()
        TempLogStart()
    
        Args = New clsAutoCompleteEventArgs()
    
        With Args
          .Cancel = False
          .AutoCompleteList = Me.myAutoCompleteList
    
          If myLbox.SelectedIndex = -1 Then
            .SelectedIndex = 0
          Else
            .SelectedIndex = myLbox.SelectedIndex
          End If
        End With
    
        RaiseEvent BeforeDisplayingAutoComplete(Me, Args)
    
        Me.myAutoCompleteList = Args.AutoCompleteList
    
        'If Me.myAutoCompleteList IsNot Nothing AndAlso Me.myAutoCompleteList.Count - 1 < Args.SelectedIndex Then
        '  Args.SelectedIndex = Me.myAutoCompleteList.Count - 1
        'End If
    
        If Not Args.Cancel AndAlso Args.AutoCompleteList IsNot Nothing AndAlso Args.AutoCompleteList.Count > 0 Then
          Call DoShowAuto()
        Else
          Call DoHideAuto()
        End If
        TempLogStop()
      End Sub
    
      Private Sub DoShowAuto()
        Call SaveSelects()
    
        TempLogStart()
        Static First As Boolean = True
        myLbox.BeginUpdate()
        Try
          myLbox.Items.Clear()
          myLbox.Items.AddRange(Me.myAutoCompleteList.ToArray)
    
          Call Me.MoveLBox(Args.SelectedIndex)
        Catch ex As Exception
        End Try
        myLbox.EndUpdate()
    
    
        myParentForm = GetParentForm(Me)
        If myParentForm IsNot Nothing Then
          myLbox.Name = "mmmlbox" & Now.Millisecond
          If myForm.Visible = False Then
            myForm.Font = Me.Font
            myLbox.Font = Me.Font
    
            myLbox.Visible = True
            myForm.Visible = False
    
            myForm.ControlBox = False
    
            myForm.Text = ""
    
            If First Then
              myForm.Width = Me.Width
              myForm.Height = 200
            End If
    
            First = False
    
            If Not myForm.Controls.Contains(myLbox) Then myForm.Controls.Add(myLbox)
            myForm.FormBorderStyle = FormBorderStyle.None
            myForm.ShowInTaskbar = False
    
            With myLbox
              .Dock = DockStyle.Fill
              .SelectionMode = SelectionMode.One
            End With
    
            'Frm.Controls.Add(myLbox)
    
            DontHide = True
    
            SuspendFocus = True
    
    
            myForm.TopMost = True
            myForm.FormBorderStyle = Me.myAutoCompleteFormBorder
    
            myForm.BringToFront()
            Call MoveDrop()
            myForm.Visible = True
            myForm.Show()
            Call MoveDrop()
    
            HideTimer.Interval = 10
    
            Me.Focus()
    
            SuspendFocus = False
    
            HideTimer.Enabled = True
    
            DontHide = False
    
            Call LoadSelects()
          End If
        End If
        TempLogStop()
    
      End Sub
    
      Sub MoveDrop()
    
        TempLogStart()
        Dim Pnt As Point = New Point(Me.Left, Me.Top + Me.Height + 2)
        Dim ScreenPnt As Point = Me.PointToScreen(New Point(-2, Me.Height))
    
        'Dim FrmPnt As Point = Frm.PointToClient(ScreenPnt)
        If myForm IsNot Nothing Then
          myForm.Location = ScreenPnt
    
          'myForm.BringToFront()
    
    
          'myForm.Focus()
          'myLbox.Focus()
    
          'Me.Focus()
        End If
        TempLogStop()
      End Sub
    
      Sub DoHide(ByVal sender As Object, ByVal e As EventArgs)
    
        TempLogStart()
        Call HideAuto()
        TempLogStop()
      End Sub
    
      Private Sub DFocus(Optional ByVal Delay As Integer = 10)
    
        TempLogStart()
        FocusTimer.Interval = Delay
        FocusTimer.Start()
        TempLogStop()
      End Sub
    
      Private Sub DoHideAuto()
    
        TempLogStart()
        myForm.Hide()
    
        HideTimer.Enabled = False
        FocusTimer.Enabled = False
        TempLogStop()
      End Sub
    
      Private Sub HideAuto()
    
        TempLogStart()
        If myForm.Visible AndAlso HasLostFocus() Then
          Call DoHideAuto()
        End If
        TempLogStop()
      End Sub
    
      Private Function HasLostFocus() As Boolean
    
        TempLogStart()
        Dim Out As Boolean
    
        If Me.myForm Is Nothing OrElse myForm.ActiveControl IsNot Me.myLbox Then
          Out = True
        End If
    
        If Me.myParentForm Is Nothing OrElse Me.myParentForm.ActiveControl IsNot Me Then
          Out = True
        End If
    
        TempLogStop()
        Return Out
      End Function
    
      Private Function GetParentForm(ByVal InCon As Control) As Form
    
        TempLogStart()
        Dim TopCon As Control = FindTopParent(InCon)
        Dim Out As Form = Nothing
    
        If TypeOf TopCon Is Form Then
          Out = CType(TopCon, Form)
        End If
    
        TempLogStop()
        Return Out
      End Function
    
      Private Function FindTopParent(ByVal InCon As Control) As Control
    
        TempLogStart()
        Dim Out As Control
    
        If InCon.Parent Is Nothing Then
          Out = InCon
        Else
          Out = FindTopParent(InCon.Parent)
        End If
    
        TempLogStop()
        Return Out
      End Function
    
      Public Class clsAutoCompleteEventArgs
        Inherits EventArgs
    
        Private myAutoCompleteList As List(Of String)
        Private myCancel As Boolean
    
        Private mySelectedIndex As Integer
    
        Public Property SelectedIndex() As Integer
          Get
            Return mySelectedIndex
          End Get
          Set(ByVal value As Integer)
            mySelectedIndex = value
          End Set
        End Property
    
        Public Property Cancel() As Boolean
          Get
            Return myCancel
          End Get
          Set(ByVal value As Boolean)
            myCancel = value
          End Set
        End Property
    
        Public Property AutoCompleteList() As List(Of String)
          Get
            Return myAutoCompleteList
          End Get
          Set(ByVal value As List(Of String))
            myAutoCompleteList = value
          End Set
        End Property
      End Class
    
      Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
    
        TempLogStart()
        TempLogStop()
        MyBase.OnKeyUp(e)
    
        Call ShowOnChar(Chr(e.KeyValue))
      End Sub
    
      Private Sub ShowOnChar(ByVal C As String)
    
        TempLogStart()
        TempLogStop()
        If IsPrintChar(C) Then
          Call Me.ShowAutoComplete()
        End If
      End Sub
    
      Private Function IsPrintChar(ByVal C As Integer) As Boolean
    
        TempLogStart()
        TempLogStop()
        Return IsPrintChar(Chr(C))
      End Function
    
      Private Function IsPrintChar(ByVal C As Byte) As Boolean
    
        TempLogStart()
        TempLogStop()
        Return IsPrintChar(Chr(C))
      End Function
    
      Private Function IsPrintChar(ByVal C As Char) As Boolean
    
        TempLogStart()
        TempLogStop()
        Return IsPrintChar(C.ToString)
      End Function
    
      Private Function IsPrintChar(ByVal C As String) As Boolean
    
        TempLogStart()
        If System.Text.RegularExpressions.Regex.IsMatch(C, "[^\t\n\r\f\v]") Then
          Return True
        Else
          Return False
        End If
        TempLogStop()
      End Function
    
      Private Sub clsCustomAutoCompleteTextbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
    
        TempLogStart()
        If Not Me.SuspendFocus AndAlso Me.myShowAutoCompleteOnFocus AndAlso Me.myForm.Visible = False Then
          Call Me.ShowAutoComplete()
        End If
        TempLogStop()
      End Sub
    
      Private Sub clsCustomAutoCompleteTextbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    
        TempLogStart()
        If Not SelectItem(e.KeyCode) Then
          If e.KeyCode = Keys.Up Then
            If myLbox.SelectedIndex > 0 Then
              Call MoveLBox(myLbox.SelectedIndex - 1)
            End If
          ElseIf e.KeyCode = Keys.Down Then
            Call MoveLBox(myLbox.SelectedIndex + 1)
          End If
        End If
        TempLogStop()
      End Sub
    
      Shadows Sub SelectAll()
    
      End Sub
    
      Private Sub MoveLBox(ByVal Index As Integer)
    
        TempLogStart()
        Try
          If Index > myLbox.Items.Count - 1 Then
            Index = myLbox.Items.Count - 1
          End If
    
          myLbox.SelectedIndex = Index
        Catch ex As Exception
    
        End Try
        TempLogStop()
      End Sub
    
      Private Sub clsCustomAutoCompleteTextbox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
    
        TempLogStart()
        Call DoHide(sender, e)
        TempLogStop()
      End Sub
    
      Private Sub clsCustomAutoCompleteTextbox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
    
        TempLogStart()
        Call DoHide(sender, e)
        TempLogStop()
      End Sub
    
      Private Sub clsCustomAutoCompleteTextbox_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
    
        TempLogStart()
        Call MoveDrop()
        TempLogStop()
      End Sub
    
      Private Sub clsCustomAutoCompleteTextbox_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
    
        TempLogStart()
        myParentForm = GetParentForm(Me)
        TempLogStop()
      End Sub
    
      Private Sub HideTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles HideTimer.Tick
    
        TempLogStart()
        Call MoveDrop()
        Call DoHide(sender, e)
    
        Static Cnt As Integer = 0
    
        Cnt += 1
    
        If Cnt > 300 Then
          If Not AppHasFocus() Then
            Call DoHideAuto()
          End If
    
          Cnt = 0
        End If
        TempLogStop()
      End Sub
    
      Public Overrides Property SelectedText() As String
        Get
          Return MyBase.SelectedText
        End Get
        Set(ByVal value As String)
          MyBase.SelectedText = value
        End Set
      End Property
    
      Public Overrides Property SelectionLength() As Integer
        Get
          Return MyBase.SelectionLength
        End Get
        Set(ByVal value As Integer)
          MyBase.SelectionLength = value
        End Set
      End Property
    
      Private Sub myLbox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles myLbox.Click
    
    
      End Sub
    
      Private Sub myLbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles myLbox.DoubleClick
    
      End Sub
    
      Private Function SelectItem(Optional ByVal Key As Keys = Keys.None, _
                             Optional ByVal SingleClick As Boolean = False, _
                             Optional ByVal DoubleClick As Boolean = False) As Boolean
    
    
        TempLogStart()
        Dim DoSelect As Boolean = True
        Dim Meth As SelectOptions
        Static LastItem As Integer = -1
        Select Case True
          Case Me.mySelectionMethods And SelectOptions.OnEnterPress AndAlso Key = Keys.Enter
            Meth = SelectOptions.OnEnterPress
          Case Me.mySelectionMethods And SelectOptions.OnRightArrow AndAlso Key = Keys.Right
            Meth = SelectOptions.OnRightArrow
          Case Me.mySelectionMethods And SelectOptions.OnTabPress AndAlso Key = Keys.Tab
            Meth = SelectOptions.OnTabPress
          Case Me.mySelectionMethods And SelectOptions.OnSingleClick AndAlso SingleClick
            Meth = SelectOptions.OnSingleClick
          Case Me.mySelectionMethods And SelectOptions.OnDoubleClick AndAlso DoubleClick
            Meth = SelectOptions.OnDoubleClick
            'Case Me.mySelectionMethods And SelectOptions.OnItemChange AndAlso (LastItem <> myLbox.SelectedIndex)
          Case Else
            DoSelect = False
        End Select
        LastItem = myLbox.SelectedIndex
        If DoSelect Then
          Call DoSelectItem(Meth)
        End If
        TempLogStop()
    
        Return DoSelect
      End Function
    
      Private Sub DoSelectItem(ByVal Method As SelectOptions)
    
        TempLogStart()
        If Me.myLbox.Items.Count > 0 AndAlso Me.myLbox.SelectedIndex > -1 Then
          Dim Value As String = Me.myLbox.SelectedItem.ToString
    
          Dim Orig As String = Me.Text
    
          Me.Text = Value
    
          If mySelectTextAfterItemSelect Then
            Try
              Me.SelectionStart = Orig.Length
              Me.SelectionLength = Value.Length - Orig.Length
            Catch ex As Exception
            End Try
          Else
            'Me.SelectionStart = Me.Text.Length
            'Me.SelectionLength = 0
          End If
    
          RaiseEvent ItemSelected(Me, New clsItemSelectedEventArgs(Me.myLbox.SelectedIndex, Method, Value))
    
          Call Me.DoHideAuto()
        End If
        TempLogStop()
      End Sub
    
      Public Class clsItemSelectedEventArgs
        Private myIndex As Integer
        Private myMethod As SelectOptions
        Private myItemText As String
    
        Public Property ItemText() As Boolean
          Get
            Return myItemText
          End Get
          Set(ByVal value As Boolean)
            myItemText = value
          End Set
        End Property
    
        Public Property Method() As SelectOptions
          Get
            Return myMethod
          End Get
          Set(ByVal value As SelectOptions)
            myMethod = value
          End Set
        End Property
    
        Public Property Index() As Integer
          Get
            Return myIndex
          End Get
          Set(ByVal value As Integer)
            myIndex = value
          End Set
        End Property
    
        Sub New()
    
        End Sub
        Sub New(ByVal Index As Integer, ByVal Method As SelectOptions, ByVal ItemText As String)
          myIndex = Index
          myMethod = Method
          myItemText = ItemText
        End Sub
      End Class
    
      Private Sub myLbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles myLbox.GotFocus
    
        TempLogStart()
        Call DFocus()
        TempLogStop()
      End Sub
    
      Private Sub myLbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles myLbox.KeyDown
    
        TempLogStart()
        Call SelectItem(e.KeyCode)
        TempLogStop()
      End Sub
    
      Private Sub ProcessKeyEvents(ByVal e As KeyEventArgs)
    
        TempLogStart()
        Select Case e.KeyCode
          Case Is >= Keys.A And e.KeyCode <= Keys.Z
            MyBase.OnKeyUp(e)
          Case Keys.Back
    
          Case Keys.Enter
    
          Case Keys.Left, Keys.Right, Keys.Up, Keys.Down
    
          Case Is >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9, Is >= Keys.D0 And e.KeyCode <= Keys.D9
    
        End Select
        TempLogStop()
      End Sub
    
      Private Sub myLbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles myLbox.KeyPress
        If IsPrintChar(e.KeyChar) Then
          'Me.OnKeyPress(e)
          'Call MoveDrop()
        End If
        TempLogStop()
      End Sub
    
      Private Sub myLbox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles myLbox.KeyUp
        If IsPrintChar(e.KeyValue) Then
          'Me.OnKeyUp(e)
          'Call MoveDrop()
        End If
        TempLogStop()
      End Sub
    
      Private Sub myLbox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles myLbox.LostFocus
    
        TempLogStart()
        Call DoHide(sender, e)
        TempLogStop()
      End Sub
    
      Private Sub myLbox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myLbox.MouseClick
    
        TempLogStart()
        'If e.Button <> Windows.Forms.MouseButtons.None Then
        Call SelectItem(SingleClick:=True)
    
        'End If
        TempLogStop()
      End Sub
    
      Private Sub myLbox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myLbox.MouseDoubleClick
    
        TempLogStart()
        'If e.Button <> Windows.Forms.MouseButtons.None Then
        Call SelectItem(DoubleClick:=True)
    
        'End If
        TempLogStop()
      End Sub
    
      Private Sub myForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles myForm.Deactivate
    
        TempLogStart()
        Call TryHideFormWindowsDeactivated()
        TempLogStop()
      End Sub
    
      Private Sub myParentForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles myParentForm.Deactivate
    
        TempLogStart()
        Call TryHideFormWindowsDeactivated()
        TempLogStop()
      End Sub
    
      Private Sub FocusTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FocusTimer.Tick
    
        TempLogStart()
        Me.Focus()
        TempLogStop()
      End Sub
    
      Public Sub New()
    
      End Sub
    
      Private Sub myLbox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myLbox.MouseDown
        myLbox_MouseClick(sender, e)
      End Sub
    End Class
    
    #End Region
