    start-job -name Job1 -ScriptBlock {
    
    Add-Type -typedef @"
        
        namespace MyProgram 
        {
            //-----------------------------------------
            public class Program
            //-----------------------------------------
            {
    
                //-------------------------------------
                public static void Main()
                //-------------------------------------
                {
                    // Your c# Code here
                }
    
            }
        }
    "@
    
    
    [MyProgram.Program]::Main()
    
    }
