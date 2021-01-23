    public class MyForm: Form
    {
        public InternalClose = false;
    
        // Your code...
    
    
        private void acPredmetObravnave_Validating(object sender, CancelEventArgs e)
        {
            if (InternalClose ) return;
            if (....) MessageBox.Show("Error");
        }
    }
