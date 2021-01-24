    public interface IProgress
    {
        /// <summary>
        /// Call this first to indicate how many units of work are expected to be completed.
        /// </summary>
        /// <param name="numberOfStepsToExpect">The number of units of work to expect.</param>
        void ExpectSteps(int numberOfStepsToExpect);
        /// <summary>
        /// Call this each time you complete a unit of work.
        /// </summary>
        void CompleteStep();
    }
