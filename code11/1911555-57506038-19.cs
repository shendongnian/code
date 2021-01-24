    public class AnAwesomeCountBehaviour : AnAwesomeBehaviour 
    {
        // I have to implement this
        public override void DoYourThing(string value)
        {
            Horse = value;
            Debug.Log($"Look I now have {amountOfHorses} {Horse}" + (amountOfHorses == 1 ? "" : "s"));
        }
        // and optionally CAN extend or overwrite this
        protected override void Start()
        {
            //also optional first execute whatever the original implementation does
            base.Start();
            // now add my own stuff
            Debug.Log($"First I had {amountOfHorses} {Horse}" + (amountOfHorses == 1 ? "" : "s"));
        }
    } 
