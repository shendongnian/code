    [RequireComponent(typeof(Rigidbody))]
    public class VehicleController : MonoBehaviour
    {
    //Properties
    //========================================================================================================================//
    
    public VehicleSchema VehicleSchema { get; protected set; }
    
    //Methods
    //========================================================================================================================//
    
    private void FixedUpdate()
    {
        VehicleSchema.UpdateWorldState();
    }
    }
