c#
public sealed class BmrHelper
{
    #region enums
    public enum Gender
    {
        Female,
        Male,
    }
    public enum CalcUnit
    {
        Imperial,
        Metric,
    }
    #endregion
    #region Constructors
    private BmrHelper() { } 
    #endregion        
    #region Methods
    public static double BMR(Gender gender, int age, double weight, double height, CalcUnit calcUnit = CalcUnit.Imperial)
    {
        var weightFactor = 0D;
        var heightFactor = 0D;
        var bmr = 0D;
        switch (calcUnit)
        {
            case CalcUnit.Metric:
                weightFactor = 10D;
                heightFactor = 6.25D;
                break;
            case CalcUnit.Imperial:
                weightFactor = 4.536D;
                heightFactor = 15.88D;
                break;
        }
        switch(gender)
        {
            case Gender.Female:
                bmr = (weightFactor * weight) + (heightFactor * height) - (5 * age) - 161;
                break;
            case Gender.Male:
                bmr = (weightFactor * weight) + (heightFactor * height) - (5 * age) + 5;
                break;
        }
        return bmr;
    }
    #endregion
}
In your implementation, assuming you have a gender combo box with Female and Male items respectively, text boxes for age, weight, and height inputs. A label to show the result:
> Also, you may want to add one more combo box to pass the unit of the
> factors. Imperial and Metric items respectively.
c#
private void button1_Click(object sender, EventArgs e)
{
    //Validate the inputs
    if (cboGender.SelectedIndex == -1) return;
    if (!int.TryParse(txtAge.Text, out int age))
    {
        MessageBox.Show("Error: Age...");
        return;
    }
    if (!double.TryParse(txtWeight.Text, out double weight))
    {
        MessageBox.Show("Error: Weight...");
        return;
    }
    if (!double.TryParse(txtHeight.Text, out double height))
    {
        MessageBox.Show("Error: Height...");
        return;
    }
    //
    var gender = (BmrHelper.Gender)cboGender.SelectedIndex;
    var bmr = BmrHelper.BMR(gender, age, weight, height);
    //or this to use the metric unit instead of the default imperial unit.
    //var bmr = BmrHelper.BMR(gender, age, weight, height, BmrHelper.CalcUnit.Metric);
    lblBmrResult.Text = bmr.ToString();
}
Good luck.
