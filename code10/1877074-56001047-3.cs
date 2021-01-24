    public class ShapeMover : MonoBehaviour, MyInput.IPlayerActions
    {
    	private MyInput _inputs;
    
    	public void Awake()
    	{
    		_inputs = new MyInput();
    		_inputs.Player.SetCallbacks(this);
    	}
    
    	public void OnEnable()
    	{
    		_inputs.Player.Enable();
    	}
    
    	public void OnDisable()
    	{
    		_inputs.Player.Disable();
    	}
    
    	public void OnMovement(InputAction.CallbackContext context)
    	{
    		Vector2 delta = context.ReadValue<Vector2>();
    		transform.position += new Vector3(delta.x, 0, delta.y);
    	}
    
    	public void OnDrop(InputAction.CallbackContext context)
    	{
    		//TODO
    	}
    
    	// ...
    }
