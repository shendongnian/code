    if(system.IO.Directory.Exists(c://gg==false))//we r checking the folder "gg",already available in drive c: or not
    (
    System.IO.Directory.Createdirectory("C:\\gg//");
    System.IO.File.Create("C:\\gg//textbox1.text");//textbox1 having the file name.
    }
    else
    {
    Response.Write("ALREADY FOLDER EXIST");
    }
    } 
