        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        namespace ConsoleApplication1
        {
            public abstract class BaseSqlInterface
            {
                protected abstract bool IsSafe(string instruction);
                public void Execute(string sqlStatement)
                {
                    if (IsSafe(sqlStatement))
                    {
                        // run the sql command
                    }
                    else
                    {
                        throw new Exception("You're evil");
                    }
                }
            }
            public class SqlInterfaceSafe : BaseSqlInterface
            {
                public override bool IsSafe(string instruction)
                {
                    return instruction.Contains("I'm not evil, I promise");
                }
            }
            public class SqlInterfaceUnsafe : BaseSqlInterface
            {
                public override  bool IsSafe(string instruction)
                {
                    return true;
                }
            }
            public static class SqlInterfaceFactory
            {
                public static BaseSqlInterface GetInstance()
                {
                    // return the actual object using IOC, switch, ... whichever method you want
                    return DateTime.Now.Day % 2 == 0 ? (BaseSqlInterface)new SqlInterfaceSafe() : new SqlInterfaceUnsafe();
                }
            }
        }
