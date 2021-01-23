    [AccessAttribute(Roles.Administrator)]
    class AdminForm : BaseForm { }
    abstract class BaseForm
    {
        protected override void OnLoad(EventArgs e)
        {
            CheckAccess(); //check current user against attribute of form
 
            base.OnLoad(e);
        }
    }
    enum Roles
    {
       Administrator,
       User
    }
    class AccessAttribute : Attribute { }
---
    class User
    {
        private bool? isAdmin;
        public bool IsAdmin
        {
            get
            {
                if (!isAdmin.HasValue) // better to move to private static method
                {
                    bool b = false;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "select IsHeAdmin from Users where Name = @UserName";
                        command.Paratemters.AddWithValue("@UserName", this.Name);
                        connection.Open();
                        b = command.ExecuteScalar() as bool? ?? false; // if null then false, otherwise assign the value
                    }
                    isAdmin = b;
                }
                return isAdmin.Value;
            }
        }
    }
