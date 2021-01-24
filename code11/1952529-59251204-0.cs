public class WaterConsumption
{
    private List<int> _DrunkCups = new List<int>();
    public int CupCapacity { get; set; }
    public void DrinkACupOfWater()
    {
        this._DrunkCups.Add(CupCapacity);
    }
    public int GetTotalWaterDrunk()
    {
        return this.DrunkCups.Sum()
    }
}
Then the content of the upper field in your form is the result of `GetTotalWaterDrunk()` and the content of the lower field of your form has to be stored in `CupCapacity`.
Let me know if it's clear to you and if it solves your problem.
