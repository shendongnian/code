    MemberInfo [] infos = myType.GetMembers();
    Object var = _something_;
    
    foreach(info in infos)
    {
       if (info.ReturnType == typeof(var))
       { 
          info.Invoke(this,new object[]{var});
       }
    }
