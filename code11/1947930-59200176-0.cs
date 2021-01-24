     If cla.Length > 1 Then
            'cla(0) is the executable path.
            'cla(1) is the Path to the project
            If Not IsIDE() Then WCLicenseIsLicensed("Application", True)
            Me.Text = Application.ProductName
            mblnLoaded = True
            LoadProject(cla(1))
            TreeVieuwSystem.Nodes(cla(2)).Expand()
            TreeVieuwSystem.SelectedNode = TreeVieuwSystem.Nodes(cla(2)).Nodes.Find(cla(2) & "\" & cla(3), True).First
            NodeSelected()
            If cla(2) = "Test Plans" Then
                TheWindowThatAllowsYouToEditTheObject.RunTestPlan()
            ElseIf cla(2) = "Tests" Then
                TheWindowThatAllowsYouToEditTheObject.RunTest(False)
            End If
        Else
