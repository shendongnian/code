    public class TestMovement : MonoBehaviour
    {
        public float Speed;
        public FloatingJoystick Joystick; //Set in the inspector, prefab from the asset
        private void Update()
        {
            transform.Translate(new Vector2(Joystick.Horizontal, Joystick.Vertical) * Speed * Time.deltaTime);
        }
    }
