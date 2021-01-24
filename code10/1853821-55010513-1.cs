    public class Toggler
    {
    bool state = false;
    public void ToggleState()
    {
        state = !state; // This sets a Boolean value to the opposite of itself
        if (state)
        {
            // State was just toggled on
        }else{
            // State was just toggled off
        }
    }
    }
