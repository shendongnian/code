    public class Story
    {
        public void GiveAward(Nominator nominator)
        {
            if (this.Award != null)
                throw new ...
            var award = nominator.CreateAwardForStory(this); 
            this.SetAward(award); // SetAward can now be private
        }
    }
    public class Nominator
    {
        public Award CreateAwardForStory(Story story)
        {
            if (BusinessUnit.HasAwardsToGive() == false)
                throw new ...
            return new Award(AwardType.Results);
        }
    }
