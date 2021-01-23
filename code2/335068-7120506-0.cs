    //Parentclass
    protected void Page_Load 
    {       
      if(info != null) 
      {
        MyControlObject myObj = new MyControlObject();
        myObj.prop1 = txt1.Text;
        myObj.prop2 = txt2.Text;
        Session["myObj"] = myObj;
      }
    } 
    
    //Childclass
    public void SetInfo(Info info)  
    {  
      MyControlObject myObj = Session["myObj"] as MyControlObject;
      if(myObj != null)
      {
        //assign the values to your controls
      }
    }  
