    using Microsoft.Dynamics.BusinessConnectorNet;
    AxaptaContainer axContainer = (AxaptaContainer)objDAXCn.Call("someClass","someStaticMethod",Var1,Var2,var3);    
    for (int i = 1; i <= axContainer.Count; i++)
    { 
        someStr = axContainer.get_Item(i).toString();
    }
