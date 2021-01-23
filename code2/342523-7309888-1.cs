public struct CInput  
{    
    public double Time;    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3650)] 
    public double[] Database;
}       
CInput Inputs = new CInput();  
int bfr = Example(ref Inputs);
