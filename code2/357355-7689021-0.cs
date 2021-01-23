    // interface for included tools to build your furniture
    public interface IToolKit {
        string[] GetTools();
    }
    // interface for included parts for your furniture    
    public interface IParts {
        string[] GetParts();
    }
    
    // represents a generic base class for IKEA furniture kit
    public abstract class IkeaKit<TContents> where TContents : IToolKit, IParts, new() {
        public abstract string Title {
            get;
        }
    
        public abstract string Colour {
            get;
        }
    
        public void GetInventory() {
            // generic constraint new() lets me do this
            var contents = new TContents();
            foreach (string tool in contents.GetTools()) {
                Console.WriteLine("Tool: {0}", tool);
            }
            foreach (string part in contents.GetParts()) {
                Console.WriteLine("Part: {0}", part);
            }
        }
    }
    
    // describes a chair
    public class Chair : IToolKit, IParts {
        public string[] GetTools() {
            return new string[] { "Screwdriver", "Allen Key" };
        }
    
        public string[] GetParts() {
            return new string[] {
                "leg", "leg", "leg", "seat", "back", "bag of screws" };
        }
    }
    
    // describes a chair kit call "Fnood" which is cyan in colour.
    public class Fnood : IkeaKit<Chair> {
        public override string Title {
            get { return "Fnood"; }
        }
    
        public override string Colour {
            get { return "Cyan"; }
        }
    }
    
    public class Snoolma : IkeaKit<Chair> {
        public override string Title {
            get { return "Snoolma "; }
        }
    
        public override string Colour {
            get { return "Orange"; }
        }
    }
