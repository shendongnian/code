    static string[] CommonSentFolderNames = { "Sent Items", "Sent Mail", "Sent Messages", /* maybe add some translated names */ };
    
    static IFolder GetSentFolder (ImapClient client, CancellationToken cancellationToken)
    {
        var personal = client.GetFolder (client.PersonalNamespaces[0]);
        
        return personal.GetSubfolders (false, cancellationToken).FirstOrDefault (x => CommonSentFolderNames.Contains (x.Name));
    }
