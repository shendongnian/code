    public static class ProgramDataMapper
    {
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
            return Program.GetProgram<DynamicProgram>(programID);
        }
    }
