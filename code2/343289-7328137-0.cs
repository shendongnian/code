    // State pattern: public "wrapper"
    public class User {
        UserState state = UserState.CreateUser();
        public void SetIsEmployer ()
        {
            // Use UserState.IsEmployer() method to transition to the
            // Employer state
            state = state.IsEmployer ();
        }
        public User Employer {
            get {return state.Employer.User;}
        }
    }
    // State pattern: User state
    internal class UserState {
        // protected so that only CreateUser() can create instances.
        protected UserState ()
        {
        }
        public User User {
            get {/* TODO */}
        }
        public virtual UserState Employer {
            get {return null;}
        }
        // Creates a default prototype instance
        public static UserState CreateUser ()
        {
             return new UserState ();
        }
        // Prototype-ish method; creates an EmployerState instance
        public virtual UserState IsEmployer ()
        {
            return new EmployerState (/* data to copy...*/);
        }
    }
    // State pattern: Employer state
    class EmployerState : UserState {
        internal EmployeeState ()
        {
        }
        public override UserState Employer {
            get {return this;}
        }
    }
