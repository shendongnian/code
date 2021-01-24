    public partial class Incident: ICloneable {
        object ICloneable.Clone() {
            return new Incident {
                IncidentID = Guid.NewGuid,  // New ID 
                Name = this.Name            // Keeping the exising value 
            };
        }
    }
