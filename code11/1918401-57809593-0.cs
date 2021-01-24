    public class SetAlpha : Monobehaviour
    {
        public Material materialWithAlphaValue;
    
        public void ChangeAlphaValue(Color color)
        {
            materialWithAlphaValue.SetColor("_MY_SHADER_VARIABLE_NAME", color);
        }
    }
