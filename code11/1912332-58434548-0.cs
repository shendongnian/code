DTE2 dte2 = Package.GetGlobalService(typeof(DTE)) as DTE2;
foreach (Document doc in dte2.Documents)
{
    if (doc.FullName == Moniker)
    {
        doc.Activate();
        return;
    }
}
This traverses the currently opened documents until it finds the one I want to activate and activates it, just like I wanted :)
