    public class MyClass
    {
        public Form CreateForm()
        {
            var form = new MyForm();
            form.Button1.Click += HandleButton1Clicked;
            return form;
        }
    
        private void HandleButton1Clicked(object sender, EventArgs e)
        {
            // do whatever you need to do when Button1 is clicked
        }
    }
