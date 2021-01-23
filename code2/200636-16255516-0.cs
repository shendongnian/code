    public class DotNetTips     
    {     
    private void DoSomeOperation()     
    {     
    using (SqlConnection con1 = new SqlConnection("First Connection String"), 
    			con2 = new SqlConnection(("Second Connection String"))     
    {     
    // Rest of the code goes here     
    }     
    }
    
    private void DoSomeOtherOperation()    
    {     
    using (SqlConnection con = new SqlConnection("Connection String"))     
    using (SqlCommand cmd = new SqlCommand())     
    {     
    // Rest of the code goes here     
    }     
    }     
    }
    Using statement is useful when we have to call dispose method multiple times on different objects. Otherwise, we will have to call Dispose method on each object as:
    
     
    if (con != null) con.Dispose();     
    if (cmd != null) cmd.Dispose();  
