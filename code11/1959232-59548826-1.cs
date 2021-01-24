    public class NonObscuredIDProvider : IObscuredIDProvider
    {
        public string GetObscuredID(int id)
        {
            return id.ToString();
        }
        public void SetObscuredID(int id, string obscuredID)
        {
            // noop
        }
    }
