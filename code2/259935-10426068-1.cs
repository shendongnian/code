    //In A.aspx
    //Serialize.
    Object obj = MyObject;
    Session["Passing Object"] = obj;
    
    //In B.aspx
    //DeSerialize.
    MyObject obj1 = (MyObject)Session["Passing Object"];
    
    Returntype of the method xyx = obj.Method;//Using the deserialized data.
