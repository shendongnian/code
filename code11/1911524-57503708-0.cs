    public class InputBinding
    {
    	public GameInputsEnum InputName { get; private set; }
    	public InputTypeEnum InputType { get; private set; }
    	public string InputButton { get; private set; }
    	public KeyCode InputKey { get; private set; }
    	public int InputMouseButton { get; private set; }
    
    	public InputBinding(GameInputsEnum inputName, InputTypeEnum inputType, string inputButton, KeyCode inputKey, int mouseButton)
    	{
    		this.InputName = inputName;
    		this.InputType = inputType;
    		this.InputButton = inputButton;
    		this.InputKey = inputKey;
    		this.InputMouseButton = mouseButton;
    	}
    }
