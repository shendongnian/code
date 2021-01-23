    var rsxr = new ResXResourceReader("Test.resx");
    rsxr.UseResXDataNodes = true;
    foreach (DictionaryEntry de in rsxr)
    {
        var node = (ResXDataNode)de.Value;
        //FileRef is null if it is not a file reference.
        if (node.FileRef == null)
        {
            //Spell check your value.
            var value = node.GetValue((ITypeResolutionService) null);
        }
    }
