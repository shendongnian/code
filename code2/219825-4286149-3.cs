    ''' <summary>
    ''' Gets a user NetBiosName.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    ''' The first part is to find the domain NetBiosName which should occur to be the "fully" part of your domain LDAP path. The 
    ''' code provided below illustrates on how you may search the partitions and configurations to get the NetBiosName.
    ''' </para>
    ''' <para>
    ''' The second part is to search for one user into the domain for the existance of a given in parameter user login. If the 
    ''' user is found, then it is the right domain for this user, hence concatenating both the obtained NetBiosName and login,
    ''' separated by a backslash (<b>\</b>) character.
    ''' </para>
    ''' </remarks>
    <TestCase("TestUser1")> _
    Public Sub GetUserNetBiosName(ByVal pLogin As String)
        Dim netBIOSName As String = Nothing
        Dim serverAddress As String = "LDAP://fully.qualified.domain.name"
        Using root As DirectoryEntry = New DirectoryEntry(String.Concat(serverAddress, "/RootDSE"))
            Dim domain As String = CType(root.Properties("defaultNamingContext")(0), String)
            If (Not String.IsNullOrEmpty(domain)) Then
                Using parts As DirectoryEntry = New DirectoryEntry(String.Concat("LDAP://CN=Partitions,CN=Configuration,", domain))
                    Try
                        For Each p As DirectoryEntry In parts.Children
                            If (String.Equals(domain, CType(p.Properties("nCName")(0), String))) Then
                                netBIOSName = CType(p.Properties("netBIOSName").Value, String)
                                Exit For
                            End If
                        Next
                    Finally
                        parts.Dispose()
                    End Try
                End Using
            End If
        End Using
        Assert.AreEqual("FULLY", netBIOSName)
        Using root As DirectoryEntry = New DirectoryEntry(serverAddress)
            Using searcher As DirectorySearcher = New DirectorySearcher()
                searcher.SearchRoot = root
                searcher.SearchScope = SearchScope.Subtree
                searcher.PropertiesToLoad.Add("sAMAccountName")
                searcher.Filter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pLogin)
                Dim result As SearchResult = Nothing
                Try
                    result = searcher.FindOne()
                    If (result IsNot Nothing) Then
                        Dim user As DirectoryEntry = result.GetDirectoryEntry()
                        netBIOSName = String.Concat(netBIOSName, "\", CType(user.Properties("sAMAccountName").Value, String))
                    End If
                Finally
                    If (result IsNot Nothing) Then _
                        result = Nothing
                End Try
            End Using
        End Using
        Assert.AreEqual("FULLY\TESTUSER1", netBIOSName.ToUpperInvariant())
    End Sub
    
