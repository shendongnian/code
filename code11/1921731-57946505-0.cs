	using System;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public partial class Form1 : Form
		{
			//https://docs.microsoft.com/en-us/dotnet/api/system.random.-ctor?view=netframework-4.8
			// The default seed value is derived from the system clock, which has finite resolution. 
			// As a result, on the .NET Framework only, different Random objects that are created in 
			// close succession by a call to the parameterless constructor will have identical default 
			// seed values and, therefore, will produce identical sets of random numbers. This problem 
			// can be avoided by using a single Random object to generate all random numbers.
			private readonly Random objRandom = new Random();
			//Everytime the button is clicked, this array is loaded with 3 random numbers
			private int[] theNumbers;
			public Form1()
			{
				InitializeComponent();
			}
			   
			private void Button1_Click(object sender, EventArgs e)
			{
				theNumbers = GenerateThreeRandomsEachLessThanTen();
				//just to demo the creation of the numbers
				textBox1.Text = String.Join(Environment.NewLine, theNumbers);
			}
			private int[] GenerateThreeRandomsEachLessThanTen()
			{
				return new int[] { objRandom.Next(10), objRandom.Next(10), objRandom.Next(10) };
			}
		}
	}
