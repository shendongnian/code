    public int EmpCode
    {
        get { return _strEmpCode >0 ? 100+_strEmpCode : 0; }
        set {
    
    if(value > 0)
     _strEmpCode = value; 
}
    }  
