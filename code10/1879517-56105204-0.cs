    //Get employee list
    
    List<Entity.Employee> lstEmployees = new List<Entity.Employee>();
    
    lstEmployees = Logic.Employee.getEmployees(DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList3.SelectedValue, DropDownList4.SelectedValue);
    
    foreach(Employee emp in lstEmployees)
    {
    	String MyKey = DropDownList1.SelectedValue + DropDownList2.SelectedValue + DropDownList3.SelectedValue + DropDownList4.SelectedValue;
    	if(Application[MyKey]==null || Application[MyKey]=""){
    		//single process per user required
    	}
    }
    
    //release single process
