        Try
            'If destination directory does not exist, create it first.
            If Not Directory.Exists(path) Then Directory.CreateDirectory(path)
            Dim dir As New DirectoryInfo(path)
            Dim dirsec As DirectorySecurity = dir.GetAccessControl()
            'Remove inherited permissions
            dirsec.SetAccessRuleProtection(True, False)
            'create rights, include subfolder and files to be inherited by this
            Dim Modify As New FileSystemAccessRule(username, FileSystemRights.Modify, InheritanceFlags.ContainerInherit + InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow)
            Dim Full As New FileSystemAccessRule(admingroup, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit + InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow)
            dirsec.AddAccessRule(Modify)
            dirsec.AddAccessRule(Full)
            'Set
            dir.SetAccessControl(dirsec)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
