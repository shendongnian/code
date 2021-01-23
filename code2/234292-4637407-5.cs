    public class MyClass
    {
        public int GetValue()
        {
            var form = new MyForm();
            if(form.ShowDialog() == DialogResult.OK) // this will block until form is closed
            {
                // return some value based on form.ButtonClicked
                // adjust method's return type as necessary
            }
            else 
            {
                // do something if the user closed the form without 
                // clicking on one of the buttons
            }
        }
    }
