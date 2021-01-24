    public class SetAlpha : MonoBehaviour
    {
        public Material materialWithAlphaValue;
    
        public void ChangeAlphaValue(Color color)
        {
            materialWithAlphaValue.SetColor("_MY_COLOR_SHADER_VARIABLE_NAME", color);
        }
    }
