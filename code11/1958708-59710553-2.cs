    public enum HumanControls
    {
        sprint,
        jump,
        ...
        openInventory
    }
    
    public class HumanController : Controller<HumanControls>
    {
    
        public static Action[] actionList = new Action[]
        {
            // movement
            new Action("Sprint", Action.InputType.Hold, KeyCode.LeftShift),
            new Action("Jump", Action.InputType.Impulse, KeyCode.Space),
            ...
            new Action("Open Inventory", Action.InputType.Toggle, KeyCode.Tab),
        };
    
        public override Action[] actions { get; } = actionList;
    
    }
