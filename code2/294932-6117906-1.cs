    /// <summary>
    /// States Repository
    /// </summary>
    public class StatesRepository : DataContextWrapper<DEMODataContext>
    {
        /// <summary>
        /// Get all active states
        /// </summary>
        /// <returns>All active states</returns>
        public IEnumerable<State> GetStates()
        {
            return base.GetItems<State>();
        }
        /// <summary>
        /// Get all active states
        /// </summary>
        /// <param name="pattern">State pattern</param>
        /// <returns>All active states tha contain the given pattern</returns>
        public IEnumerable<State> GetStates(string pattern)
        {
            return base.GetItems<State>(s=>s.Description.Contains(pattern));
        }
    }
