    List<MyModelClass> mmcList = new List<MyModelClass>();
    while (teller < onderdanen.Length){
    onderdaan = onderdanen[teller].ToString();
    SqlCommand cmd2 = new SqlCommand("SELECT M.Mod_ID AS Modelnr, M.Mod_Naam AS Modelnaam, M.Mod_Omschrijving AS Omschrijving, M.Taal_Id, M.User_ID FROM Toewijzing T, Model M WHERE T.User_ID = '" + onderdaan + "' AND T.Toe_Status = '" + "ja" + "' AND M.Mod_ID = T.Mod_ID", con);
    dr = cmd2.ExecuteReader(); 
    if(dr!=null && dr.HasRows){
    MyModelClass mmcObj= new MyModelClass();
    dr.Read();
    mmcObj.Modelnr = dr["Modelnr"].ToString(); //Modelnr is String property in MyModelClass
    mmcObj.Modelnaam= dr["Modelnaam"].ToString();//Modelnaam is a String prop in MyModelClass
    ...///so on other properties
    
    mmcList.Add(mmcObj);
    }
    dr.Close();                 
    teller++;
    } 
    gvModelAdmin.DataSource = mmcList; //set gv datasourc to the list on myModelClass
    gvModelAdmin.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
    gvModelAdmin.DataBind(); 
