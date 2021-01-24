    public enum FleetType {One=1, Two=2}
    
    public void CompleteRegProcessPassV2(string role, FleetType chooseFleet)
    {
    	var fleet = (int) chooseFleet;
    	CompleteRegProcessPass(role, chooseFleet.ToString());
    }
