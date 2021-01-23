    public static class ProgramDataMapper
    {
        // Change to a generic here to manufacture any class deriving from Program.
        public static T GetProgram<T>(int programID)
            where T : Program, new()
        {
            T p = new T();
            // database stuff
            p.Name = reader["Name"].ToString();
            ...
            return p;
        }
    }
    
    public abstract class Program
    {
        // Properties
        // Manufacture a concrete class that derives from Program
        public new static T GetProgram<T>(int programID)
            where T : Program, new()
        {
            return ProgramDataMapper.GetProgram<T>(programID);
        }
    }
    
    public class DynamicProgram : Program
    {
        // Additional Business Related Properties
        public new static DynamicProgram GetProgram(int programID)
        {
            // Specifically manufacture a DynamicProgram
            return Program.GetProgram<DynamicProgram>(programID);
        }
    }
