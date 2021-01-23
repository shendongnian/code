    public interface ICustomMethods {
        string FullName {get;}
    }
    
    public partial class Employee: Entity, ICustomMethods {
        public ICustomMethods CustomMethods {
           get {return (ICustomMethods)this;}
        }
        //explicitly implemented
        string ICustomMethods.FullName {
           get { return this.FirstName + " " + this.LastName; }
        }
    }
