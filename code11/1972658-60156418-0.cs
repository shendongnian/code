    public class ProgLogic
    {
        public event Action<int> SomeValueChanged;
        //
        // your other code goes here
        //
        private void OnSomeValueChanged(int newValue)
        {
            SomeValueChanged?.Invoke(newValue);
        }
    }
