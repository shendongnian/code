    private static void ImpersonateIdentity(IntPtr logonToken)
    {
        // Retrieve the Windows identity using the specified token.
        WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);
    
        // Create a WindowsImpersonationContext object by impersonating the
        // Windows identity.
        WindowsImpersonationContext impersonationContext =
            windowsIdentity.Impersonate();
    
        Console.WriteLine("Name of the identity after impersonation: "
            + WindowsIdentity.GetCurrent().Name + ".");
        
        //Start your process here
        Process.Start("blabla.txt");
    
        Console.WriteLine(windowsIdentity.ImpersonationLevel);
        // Stop impersonating the user.
        impersonationContext.Undo();
    
        // Check the identity name.
        Console.Write("Name of the identity after performing an Undo on the");
        Console.WriteLine(" impersonation: " +
            WindowsIdentity.GetCurrent().Name);
    }
