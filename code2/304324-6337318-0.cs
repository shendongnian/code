    public class SealableObject {
        public bool IsSealed { get; private set; }
        public void Seal() {
            if (this.IsSealed)
                throw new InvalidOperationException("The object is already sealed");
            this.IsSealed = true;
        }
        protected void VerifyNotSealed() {
            if (this.IsSealed)
                throw new InvalidOperationException("Object is sealed");
        }
    }
