    public class Story
    {
        public void GiveAward(Nominator nominator)
        {
            // Business logic for validating a story is eligible for an award would 
            // go in this function. 
            var award = nominator.CreateAwardForStory(this); 
            this.SetAward(award); // SetAward can now be private
        }
    }
