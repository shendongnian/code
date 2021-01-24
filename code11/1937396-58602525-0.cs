    foreach (var item in employeeList.ToList())
            {
    
               Debug.WriteLine("ID TO PROCESS : " + item.Id);
    
               dynamic alist = getEmployeeDetail(int item.Id);  //user var or listtype or dynamic
               var json = JsonConvert.SerializeObject(alist ); //using newtonsoft.json   
         
    
            }    
    
    
    
    //this function will return the data in the List format
    public List<EmployeeDetails> getEmployeeDetail(int id)
    {
       List<EmployeeDetails> emd=new List<EmployeeDetails>();
    //call your api here
    //check for the success code 
    return emd;
    }
