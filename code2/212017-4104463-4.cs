    ///carForm
    public class carForm:Form
    {
        UpdateFrom updateForm=new UpdateForm(this.GetType());
        updateForm.Show();
    }
    
    ///parForm
    public class parForm:Form
    {
         UpdateFrom updateForm=new UpdateForm(this.GetType());
         updateForm.Show();
    }
    
    ///updateForm
    public class updateForm:Form
    {
        private readonly Type _type;
        public updateForm(Type type)
        {
            _type = type;
        }
    
        public void SomeMethod()
        {
            // check for _type here.
        }    
    }
