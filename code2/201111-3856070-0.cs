    public class MyControl : CompositeControl
    {
           public event EventHandler Success;
           ...
           void btnSubmit_Click(object sender, EventArgs e)
       {   
           //DO SOMETHING
            if (success)
            {
                 //CALL DEVELOPER'S LOGIC
                 OnSuccess();
            }
       }
        private static void OnSuccess()
        {
             if(Success != null)
             {
                  Success(this, EventArgs.Empty); //or you can pass event args you want. But you should use EventHandler<T> instead.
             }
        }
    }
