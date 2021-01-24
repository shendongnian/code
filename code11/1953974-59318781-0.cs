    public void GetMeal(Behavior behavior)
    {
        if (isAnimal(behavior))
            GetMilk();
        else
            ChangeBattery();
    }
    private bool isAnimal(Behavior behavior)
    {
        if (behavior.HasVoice 
            && behavior.HasVoice 
            && !behavior.HasBattery )
            return true;
        
        return false;
    }
    public class Behavior 
    {
        public bool HasVoice { get; set; }
        public bool HasName { get; set; }
        public bool HasBattery { get; set; }
    }
