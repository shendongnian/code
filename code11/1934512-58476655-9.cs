C#
namespace Program4_10
{
    private double calsFromFat, percentCalsFromFat;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            percentCalsFromFat = calsFromFat = 0;
        }
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            //local variables
            double totalCals;
            double fatGramsInFood;
            //Get the calories and fat grams.
            totalCals = double.Parse(numOfCaloriesTextBox.Text);
            fatGramsInFood = double.Parse(numOfFatGramsTextBox.Text);
            //Determine whether the calories and fat grams are higher than 0.
            if (totalCals >= 0 && fatGramsInFood >= 0)
            {
                if (totalCals > fatGramsInFood)
                {
                    //Calculate calories from fat.
                    calsFromFat = fatGramsInFood * 9;
                    //Calculate percentage of calories from fat.
                    percentCalsFromFat = calsFromFat / totalCals;
                    DisplayText();
                }
                else
                {
                    //Display an error message "calories must to be higher than fat grams".
                    MessageBox.Show("Calories must be higher than fat grams");
                }
            }
            else
            {
                //Display an error message "calories and fat grams need be higher than 0".
                MessageBox.Show("Calories and fat grams need to be higher than 0");
            }
        }
        private void foodLowFatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DisplayText();
        }
        private void DisplayText()
        {
            //Display percentage of calories from fat.
            resultsLabel.Text = "The number of calories from fat:" + calsFromFat.ToString() + Environment.NewLine;
            resultsLabel.Text += "Percentage of calories from fat:" + percentCalsFromFat.ToString("p") + Environment.NewLine;
            if (foodLowFatCheckBox.Checked)
            {
                if (percentCalsFromFat <= 0.3)
                    resultsLabel.Text += "The food is considered low fat";
                else
                    resultsLabel.Text += "The food is not considered low fat";
            }
        }
    }
}
