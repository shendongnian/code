    using System;
    using System.Diagnostics;
    using System.Security;
    using System.Security.Principal;
    
    // Suppose I need to run as user "foo" with password "bar"
    
    class TestApp
    {
        static void Main( string[] args )
        {
    	    string userName = WindowsIdentity.GetCurrent().Name;
    	    if( !userName.Equals( "foo" ) ) {
    	        ProcessStartInfo startInfo = new ProcessStartInfo();
    	        startInfo.FileName = "testapp.exe";
    	        startInfo.UserName = "foo";
                SecureString password;
                password.AppendChar( 'b' );
                password.AppendChar( 'a' );
                password.AppendChar( 'r' );
    	        startInfo.Password = password;
    	    
    	        startInfo.LoadUserProfile = true;
    	        startInfo.UseShellExecute = false;
    
    	        Process.Start( startInfo );    
    	        return;
    	    }
    	    // If we make it here then we're running as "foo"
        }
    }
