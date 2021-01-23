     if(abc == 2)
         {
              label2.visible = true;
              label3.visible = false;
          }
       else if(abc ==3)
          {
             label3.visible = true;
             label2.visiable = false;       
          }
    
     or use a switch statement
    
        switch(abc)
        {
           case 2:
                 label2.visible = true;
                 break;
           case 3:
                 label3.visible = true;
                 break;
           
        }
