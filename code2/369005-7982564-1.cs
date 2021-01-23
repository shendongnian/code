    [Export(typeof (ICarPart))]
    [ExportMetadata("NameCarPart","SteeringWheel")] /* is string!! */
	
    public class SteeringWheel : ICarPart {
        public int SomeMethodFromInterface(){
			... //your stuff
        }
    }
    [Export(typeof (ICarPart))]
    [ExportMetadata("NameCarPart","Engine")] /* is string!! */
	
    public class Engine : ICarPart {
        public int SomeMethodFromInterface(){
			//Each method have diferent behavior in each part.
			... //your stuff
        }
    }
    [Export(typeof (ICarPart))]
    [ExportMetadata("NameCarPart","Brakes")] /* is string!! */
	
    public class Brakes : ICarPart {
        public int SomeMethodFromInterface(){
			//Each method have diferent behavior in each part.
			... //your stuff
        }
    }
	
