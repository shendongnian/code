    public class Form2
    {
        public MyDataObj DataObj { get; set; } //obj shared by both forms
        void btnNext_Click(...)
        {
            //validate the input and set it on DataObj
            Form2 f2 = new Form2(); //Note: instead of always re-instantiating the form you may want to have it somewhere already prepared and just show it here
            f2.DataObj = DataObj; //pass the data object to second form
            f2.Show();
        }
    }
