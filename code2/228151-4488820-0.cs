	namespace TestProgram
	{
		public class WriteToLabel
		{
			Form1 form;
			
			public WriteToLabel(Form1 form)
			{
				this.form = form;
			}
			
			public void WelcomeMessage()
			{
				//Form1 myForm = new Form1();
				//myForm..  --> myForm doesn't have an 'outputLabel'?
				form.outputLabel.Text = "Welcome!";
			}
		}
	}
