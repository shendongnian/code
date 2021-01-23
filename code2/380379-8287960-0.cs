    public void btnPanel_OnClick(object sender, EventArgs e)
    {
        Lot lot = new Lot();
        lot.CommonFunction(arg1, arg2); // Pass required data
    }
    public class Lot
    {
        public void AFunction()
        {
             //Do something
             //...
             CommonFunction(arg1, arg2); // Pass required data
             //...
             //Do something
        }
        public void CommonFunction(string arg1, string arg2)
        {
            // Do some common tasks to do here
        }
    }
