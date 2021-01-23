        DTE.Windows.Item(Constants.vsWindowKindSolutionExplorer).Activate()
        Dim objProject As EnvDTE.Project
        Dim i As Long
        i = DTE.Solution.Projects.Count
        For Each objProject In DTE.Solution.Projects
            If (objProject.Name() = "csCA") Then
                Dim vsproj As VSLangProj.VSProject
                vsproj = objProject.Object
                vsproj.References.Add("C:\Users\test.dll")
            End If
        Next
