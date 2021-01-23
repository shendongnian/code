    ///carForm
    public class carForm:Form
    {
        UpdateFrom updateForm=new UpdateForm("CAR");
        updateForm.Show();
    }
    
    ///parForm
    public class parForm:Form
    {
         UpdateFrom updateForm=new UpdateForm("PAR");
         updateForm.Show();
    }
    
    ///updateForm
    public class updateForm:Form
    {
        private readonly string _key;
        public updateForm(string key)
        {
            _key = key;
        }
    
        public void SomeMethod()
        {
            // check for _key here.
        }
    }
