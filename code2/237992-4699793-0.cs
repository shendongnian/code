Class form 1
{
   button click()
   {
     using (form2 = new form 2)
     {
       if (form2.showdialog()==dialogresult.OK)
       {
          data odata = form2.Data;
          //do work
       }
     }
    }
}
Class form2
{
public property Data
{
    get;
}
   button click()
   {
     if (form valid)
      {
      this.dialogresult = dialogresult.ok;
      }
      else
      {
         this.dialogresult = dialogresult.cancel;
      }
      this.close();
   }
}
