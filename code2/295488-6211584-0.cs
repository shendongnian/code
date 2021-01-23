    FontFamily family = new FontFamily(String.Format("file:///{0}#{1}", fi.FullName, fileFonts.Families[0].Name));
    Console.WriteLine("\tFamilySource: {0}", family.Source);
    foreach (var x in family.FamilyNames)
    {
        Console.WriteLine("\tFamilyName: {0}", x);  // <------ HERE
    }
    foreach (var y in family.FamilyTypefaces)
    {
        foreach (var z in y.AdjustedFaceNames)
        {                            
            Console.WriteLine("\tTypeface: {0}",z);
        }
    }
