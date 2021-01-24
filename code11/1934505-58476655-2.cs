C#
namespace Program4_10
{
    private decimal percentCalsFromFat;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            percentCalsFromFat = 0;
        }
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            //local variables
            decimal totalCals;
            decimal fatGramsInFood;
            decimal calsFromFat;
            //Get the calories and fat grams.
            totalCals = decimal.Parse(numOfCaloriesTextBox.Text);
            fatGramsInFood = decimal.Parse(numOfFatGramsTextBox.Text);
            //Determine whether the calories and fat grams are higher than 0.
            if (totalCals >= 0 && fatGramsInFood >= 0)
            {
                if (totalCals > fatGramsInFood)
                {
                    //Calculate calories from fat.
                    calsFromFat = fatGramsInFood * 9;
 
                    //Display the calories from fat.
                    resultsLabel.Text = calsFromFat.ToString();
 
                    //Calculate percentage of calories from fat.
                    percentCalsFromFat = calsFromFat / totalCals;
 
                    //Display percentage of calories from fat.
                    resultsLabel.Text = "The number of calories from fat:" + Environment.NewLine;
                    resultsLabel.Text += "Percentage of calories from fat:" + percentCalsFromFat.ToString("p") + Environment.NewLine;
                    if (foodLowFatCheckBox.Checked && percentCalsFromFat <= 30)
                        resultsLabel.Text = "The food is considered low fat";
                    else
                        resultsLabel.Text = "The food is not considered low fat";
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
            if (foodLowFatCheckBox.Checked && percentCalsFromFat <= 30)
                resultsLabel.Text = "The food is considered low fat";
            else
                resultsLabel.Text = "The food is not considered low fat";
        }
    }
}
