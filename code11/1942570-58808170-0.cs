	public partial class Form1 : Form
	{
		// declare and allocate
		StringBuilder results = new StringBuilder();
		
		private void buttonNewAnswer_Click(object sender, EventArgs e)
		{         
			// fill the results object
			foreach (var i in answers)
			{
				results.AppendFormat("{0},", i.ToString());
			}
		}
  
		private void buttonExit_Click(object sender, EventArgs e)
		{
			// you can use the result here.
			// results
		}   
	}
