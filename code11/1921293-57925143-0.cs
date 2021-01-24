    Console.WriteLine(String.Format("The FormHeader section of form [{0}] contains the following controls:", formName));
    foreach (Microsoft.Office.Interop.Access.Control ctl in frm.Section["FormHeader"].Controls)
    {
        Console.WriteLine();
        Console.WriteLine(String.Format("    [{0}]", ctl.Name));
        Console.WriteLine(String.Format("        {0}", ctl.GetType()));
    }
    objAccess.DoCmd.Close(Microsoft.Office.Interop.Access.AcObjectType.acForm, formName);
    objAccess.CloseCurrentDatabase();
    objAccess.Quit();
