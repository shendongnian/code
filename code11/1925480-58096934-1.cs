    static string[] CommonSentFolderNames = { "Sent Items", "Sent Mail", "Sent Messages", /* maybe add some translated names */ };
    
    static IFolder GetSentFolder (ImapClient client, CancellationToken cancellationToken)
    {
        var personal = client.GetFolder (client.PersonalNamespaces[0]);
    
        foreach (var folder in personal.GetSubfolders (false, cancellationToken)) {
            foreach (var name in CommonSentFolderNames) {
                if (folder.Name == name)
                    return folder;
            }
        }
    
        return null;
    }
