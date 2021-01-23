    public class Entity
    {
        Vector3 position = Vector3.Zero;
        Matrix rotation = Matrix.Identity;
 
        public void Yaw(float amount)
        {
            this.rotation *= Matrix.CreateFromAxisAngle(this.rotation.Up, amount);
        }
 
        public void YawAroundWorldUp(float amount)
        {
            this.rotation *= Matrix.CreateRotationY(amount);
        }
 
        public void Pitch(float amount)
        {
            this.rotation *= Matrix.CreateFromAxisAngle(this.rotation.Right, amount);
        }
 
        public void Roll(float amount)
        {
            this.rotation *= Matrix.CreateFromAxisAngle(this.rotation.Forward, amount);
        }
 
        public void Strafe(float amount)
        {
            this.position += this.rotation.Right * amount;
        }
 
        public void GoForward(float amount)
        {
            this.position += this.rotation.Forward * amount;
        }
 
        public void Jump(float amount)
        {
            this.position += this.rotation.Up * amount;
        }
 
        public void Rise(float amount)
        {
            this.position += Vector3.Up * amount;
        }
    }
