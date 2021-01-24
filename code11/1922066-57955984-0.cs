    public class Incident: ICloneable {
        public Guid IncidentID {get; set;}
        public string Name {get; set;}
    
        object ICloneable.Clone() {
            return new Incident {
                IncidentID = Guid.NewGuid,  // New ID 
                Name = this.Name            // Keeping the exising value 
            };
        }
    }
